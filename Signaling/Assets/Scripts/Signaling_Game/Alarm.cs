using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _speedOfChageVolume;

    private Coroutine _changeVolume;

    public void VolumeUp()
    {
        if (_changeVolume != null)
        {
            StopCoroutine(_changeVolume);
            _changeVolume = StartCoroutine(RiseVolume());
        }
        else
        {
            _changeVolume = StartCoroutine(RiseVolume());
        }
    }

    public void VolumeDown()
    {
        if (_changeVolume != null)
        {
            StopCoroutine(_changeVolume);
            _changeVolume = StartCoroutine(DowngradeVolume());
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
