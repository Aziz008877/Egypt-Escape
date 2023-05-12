using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SlowController : MonoBehaviour
{
    [SerializeField] private Image _iceImage;
    private List<ISlowable> _slowableObjects;

    private void Start()
    {
        TimeSlowBonus.OnTimeSlowed += FindAllSlowObjects;
    }

    private void FindAllSlowObjects(Vector3 garbage)
    {
        MonoBehaviour[] allObjects = FindObjectsOfType<MonoBehaviour>();
        _slowableObjects = new List<ISlowable>();
        foreach (MonoBehaviour obj in allObjects)
        {
            if (obj.TryGetComponent(out ISlowable slowable))
            {
                _slowableObjects.Add(slowable);
            }
        }

        StartCoroutine(Slow());
    }
    
    private IEnumerator Slow()
    {
        _iceImage.DOFade(1, 1);
        foreach (var slow in _slowableObjects)
        {
            slow.SlowAction();
        }
        yield return new WaitForSeconds(3);

        _iceImage.DOFade(0, 1.5f);
        foreach (var slow in _slowableObjects)
        {
            slow.UnSlow();
        }
    }

    private void OnDestroy()
    {
        TimeSlowBonus.OnTimeSlowed -= FindAllSlowObjects;
    }
}
