using System;
using UnityEngine;

public class FallingObstacles : MonoBehaviour, IAttackable
{
    [field:SerializeField] public float DamageValue { get; set; }
    public static event Action<float> OnPlayerDamaged;

    public void Damage()
    {
        OnPlayerDamaged?.Invoke(DamageValue);
    }
}
