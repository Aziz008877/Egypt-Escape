using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IAttackable attackable))
        {
            attackable.Damage();
            Destroy(other.gameObject);
        }

        if (other.TryGetComponent(out IBonus bonus))
        {
            bonus.GiveBonus();
            Destroy(other.gameObject);
        }
    }
}
