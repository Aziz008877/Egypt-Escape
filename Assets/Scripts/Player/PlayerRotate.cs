using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private Transform _playerBody;
    private void Start()
    {
        PlayerMove.OnPlayerMoved += RotatePlayer;
    }

    private void RotatePlayer(Vector3 moveDirection)
    {
        if (moveDirection != Vector3.zero)
        {
            _playerBody.transform.forward = moveDirection;
        }
    }

    private void OnDestroy()
    {
        PlayerMove.OnPlayerMoved -= RotatePlayer;
    }
}
