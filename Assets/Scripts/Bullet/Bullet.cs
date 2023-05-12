using System;
using UnityEngine;

public class Bullet : MonoBehaviour, IAttackable, ISlowable
{
    [field:SerializeField] public float DamageValue { get; set; }
    [SerializeField] private float _flySpeed;
    public float FlySpeed
    {
        get => _flySpeed;
        set => _flySpeed = value;
    }

    public static event Action<float> OnPlayerDamaged;

    private void OnEnable()
    {
        Invoke(nameof(Die), 2);
    }

    public void Damage()
    {
        OnPlayerDamaged?.Invoke(DamageValue);
    }

    private void Update()
    {
        transform.position += transform.forward * _flySpeed * Time.deltaTime;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void SlowAction()
    {
        _flySpeed = 3;
    }

    public void UnSlow()
    {
        _flySpeed = 8;
    }
}
