using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _enemyDeadParticles;
    [SerializeField] private ParticleSystem _frozenParticles;

    private void Start()
    {
        EnemyController.OnEnemyKilled += EnemyDead;
        TimeSlowBonus.OnTimeSlowed += FrozenParticle;
    }

    private void FrozenParticle(Vector3 takePosition)
    {
        _frozenParticles.transform.position = takePosition;
        _frozenParticles.Play();
    }

    private void EnemyDead(Vector3 deathPosition)
    {
        _enemyDeadParticles.transform.position = deathPosition;
        _enemyDeadParticles.Play();
    }

    private void OnDestroy()
    {
        EnemyController.OnEnemyKilled -= EnemyDead;
        TimeSlowBonus.OnTimeSlowed -= FrozenParticle;
    }
}
