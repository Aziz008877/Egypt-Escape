using System;
using UnityEngine;

public class TimeSlowBonus : MonoBehaviour, IBonus
{
    public static event Action<Vector3> OnTimeSlowed;
    public void GiveBonus()
    {
        OnTimeSlowed?.Invoke(transform.position);
        Destroy(gameObject);
    }
}
