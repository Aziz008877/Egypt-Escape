using System;
using UnityEngine;

public class EnemyRotate : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void Update()
    {
        transform.LookAt(_player);
    }
}
