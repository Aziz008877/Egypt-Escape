using System;
using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _speed;
    public static event Action<Vector3> OnPlayerMoved;

    private void Start()
    {
        SpeedBonus.OnSpeedBonusCollected += ReceiveSpeedBonus;
    }

    private void ReceiveSpeedBonus(float bonusTime)
    {
        StartCoroutine(IncreaseSpeedTimely(bonusTime));
    }

    private IEnumerator IncreaseSpeedTimely(float bonusTime)
    {
        _speed = 12;
        yield return new WaitForSeconds(bonusTime);
        _speed = 8;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontalMove = _joystick.Horizontal;
        float verticalMove = _joystick.Vertical;

        Vector3 moveDirection = new Vector3(horizontalMove, 0, verticalMove);
        OnPlayerMoved?.Invoke(moveDirection);
        transform.Translate(moveDirection * _speed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        SpeedBonus.OnSpeedBonusCollected -= ReceiveSpeedBonus;
    }
}
