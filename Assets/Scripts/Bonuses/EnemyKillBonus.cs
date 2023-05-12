using System;
using UnityEngine;

public class EnemyKillBonus : MonoBehaviour, IBonus
{
    public static event Action OnCollectedEnemyKill;
    private void OnEnable()
    {
        Invoke(nameof(Die), 3);
    }

    public void GiveBonus()
    {
        OnCollectedEnemyKill?.Invoke();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
