using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour, ISlowable
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private Transform _spawnPlace;
    private bool _isSlowed;
    public void Attack()
    {
        AttackCoroutine();
    }

    private void AttackCoroutine()
    {
        _enemyAnimator.SetTrigger("IsAttacking");
    }

    public void SpawnBullet()
    {
        Bullet spawnedBullet = Instantiate(_bullet, _spawnPlace);
        spawnedBullet.transform.SetParent(null);
        if (_isSlowed)
        {
            spawnedBullet.FlySpeed = 3;
        }
    }

    public void SlowAction()
    {
        _isSlowed = true;
        _enemyAnimator.speed = 0.5f;
    }

    public void UnSlow()
    {
        _isSlowed = false;
        _enemyAnimator.speed = 1;
    }
}
