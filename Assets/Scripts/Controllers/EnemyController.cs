using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour, ISlowable
{
    [SerializeField] private List<EnemyAttack> _enemies;
    [SerializeField] private float _randomEnemyAttackCooldown = 1;
    private int _attackEnemyID;
    public static event Action<Vector3> OnEnemyKilled; 

    private void Start()
    {
        EnemyKillBonus.OnCollectedEnemyKill += RandomKillEnemy;
        StartCoroutine(Shoot());
        
        GameStateController.Instance.OnPlayerWon.AddListener(delegate
        {
            GameStateController.Instance.IsGameEnded = true;
        });
        
        GameStateController.Instance.OnPlayerLose.AddListener(delegate
        {
            GameStateController.Instance.IsGameEnded = true;
        });
    }

    private void RandomKillEnemy()
    {
        var randomEnemy = RandomedEnemy();
        OnEnemyKilled?.Invoke(randomEnemy.transform.position);
        Destroy(randomEnemy.gameObject);
        _enemies.Remove(randomEnemy);
    }

    private IEnumerator Shoot()
    {
        while (_enemies.Count >= 1)
        {
            if (!GameStateController.Instance.IsGameEnded)
            {
                yield return new WaitForSeconds(_randomEnemyAttackCooldown);
                var randomedEnemy = RandomedEnemy();
                randomedEnemy.Attack();
            }
            else
            {
                yield break;
            }
        }
        
        GameStateController.Instance.OnPlayerWon?.Invoke();
    }

    private EnemyAttack RandomedEnemy()
    {
        _attackEnemyID = Random.Range(0, _enemies.Count);
        return _enemies[_attackEnemyID];
    }

    public void SlowAction()
    {
        _randomEnemyAttackCooldown = 3;
    }

    public void UnSlow()
    {
        _randomEnemyAttackCooldown = 1;
    }
    
    private void OnDestroy()
    {
        EnemyKillBonus.OnCollectedEnemyKill -= RandomKillEnemy;
        
        GameStateController.Instance.OnPlayerWon.RemoveAllListeners();
        GameStateController.Instance.OnPlayerLose.RemoveAllListeners();

    }
}
