using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _thiefInside;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _speedOfChageVolume;

    private Coroutine _downgradeVolume;
    private Coroutine _riseVolume;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            _thiefInside.Invoke();
           
            if (_downgradeVolume != null)
            {
                StopCoroutine(_downgradeVolume);
                _riseVolume = StartCoroutine(RiseVolume());
            }
            else
            {
                _riseVolume = StartCoroutine(RiseVolume());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
           if(_riseVolume != null)
            {
                StopCoroutine(_riseVolume);
                _downgradeVolume = StartCoroutine(DowngradeVolume());
            }         
        }
    }

    private IEnumerator RiseVolume()
    {
        float TargetValueOfVolume = 1;

        while (_audioSource.volume < TargetValueOfVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, TargetValueOfVolume, _speedOfChageVolume * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator DowngradeVolume()
    {
        float TargetValueOfVolume = 0;

        while (_audioSource.volume > TargetValueOfVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, TargetValueOfVolume, _speedOfChageVolume * Time.deltaTime);
            yield return null;
        }
    }
}
