using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class BonusController : MonoBehaviour
{
    [SerializeField] private int _fallCoolDown;
    [SerializeField] private float _spawnYPos;
    [SerializeField] private DOTweenSettings _doTweenSettings;
    [SerializeField] private List<GameObject> _bonuses;

    private void Start()
    {
        StartCoroutine(SpawnRandomBonus());
    }

    private GameObject RandomBonus()
    {
        int attackEnemyID = Random.Range(0, _bonuses.Count);
        return _bonuses[attackEnemyID];
    }
    
    private IEnumerator SpawnRandomBonus()
    {
        while (true)
        {
            RandomCooldown();
            yield return new WaitForSeconds(_fallCoolDown);
            SpawnBonus();
        }
    }

    private void RandomCooldown()
    {
        _fallCoolDown = Random.Range(3, 6);
    }

    private void SpawnBonus()
    {
        float xPos = Random.Range(-5, 6);
        float zPos = Random.Range(-5, 6);
        var spawnedBonus = Instantiate(RandomBonus(), new Vector3(xPos, _spawnYPos, zPos), Quaternion.identity);
        
        spawnedBonus.transform
            .DOMoveY(2, _doTweenSettings.Duration)
            .SetEase(_doTweenSettings.EaseType);
    }
}
