using System;
using UnityEngine;

public class PlayerHP : MonoBehaviour, IDamageable
{
    [field:SerializeField] public float HP { get; set; }

    private void Start()
    {
        Bullet.OnPlayerDamaged += ReceiveDamage;
        FallingObstacles.OnPlayerDamaged += ReceiveDamage;
    }

    public void ReceiveDamage(float damageValue)
    {
        if (HP - damageValue > 0)
        {
            HP -= damageValue;
        }
        else
        {
            GameStateController.Instance.OnPlayerLose?.Invoke();
        }
    }

    private void OnDestroy()
    {
        Bullet.OnPlayerDamaged -= ReceiveDamage;
        FallingObstacles.OnPlayerDamaged -= ReceiveDamage;
    }
}
