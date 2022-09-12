using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _speedOfChageVolume;

    private Coroutine _volumeChenger;

    public void VolumeUp()
    {
        float TargetValueOfVolume = 1;
        
        if (_volumeChenger != null)
        {
            StopCoroutine(_volumeChenger);
            _volumeChenger = StartCoroutine(ChangeVolume(TargetValueOfVolume));
        }
        else
        {
            _volumeChenger = StartCoroutine(ChangeVolume(TargetValueOfVolume));
        }
    }

    public void VolumeDown()
    {
        float TargetValueOfVolume = 0;

        if (_volumeChenger != null)
        {
            StopCoroutine(_volumeChenger);
            _volumeChenger = StartCoroutine(ChangeVolume(TargetValueOfVolume));
        }
    }

    private IEnumerator ChangeVolume(float TargetValueOfVolume)
    {
        while (_audioSource.volume != TargetValueOfVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, TargetValueOfVolume, _speedOfChageVolume * Time.deltaTime);
            yield return null;
        }
    } 
}
