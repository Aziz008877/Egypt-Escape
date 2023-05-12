using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;
    private void Start()
    {
        PlayerMove.OnPlayerMoved += MoveAnimation;
    }

    private void MoveAnimation(Vector3 moveDirection)
    {
        if (moveDirection != Vector3.zero)
        {
            _playerAnimator.SetBool("IsRunning", true);
        }
        else
        {
            _playerAnimator.SetBool("IsRunning", false);
        }
    }

    private void OnDestroy()
    {
        PlayerMove.OnPlayerMoved -= MoveAnimation;
    }
}
