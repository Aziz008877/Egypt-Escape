using System;
using UnityEngine;

public class SpeedBonus : MonoBehaviour, IBonus
{
    [SerializeField] private float _speedBonusDuration;
    public static event Action<float> OnSpeedBonusCollected;
    public void GiveBonus()
    {
        OnSpeedBonusCollected?.Invoke(_speedBonusDuration);
    }
}
