using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _duration;
    [SerializeField] private Signaling _signaling;

    private float _runningTime;
    private float _maxVolume = 1f;
    private float _normalizeRunningTime;

    private void Update()
    {
        StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        if (_signaling.IsThiefOutSide == false)
        {
            RaiseVolume();
            yield return new WaitWhile(() => _runningTime <= _duration);
        }

        if (_signaling.IsThiefOutSide == true)
        {
            if (_runningTime > _duration)
            {
                _runningTime = _duration;
                DowngradeVolume();
            }
            else
            {
                DowngradeVolume();
            }
        }
    }

    private void DowngradeVolume()
    {
        _runningTime -= Time.deltaTime;
        _normalizeRunningTime = _runningTime / _duration;
        _audioSource.volume = _maxVolume * _normalizeRunningTime;
    }

    private void RaiseVolume()
    {
        _runningTime += Time.deltaTime;
        _normalizeRunningTime = _runningTime / _duration;
        _audioSource.volume = _maxVolume * _normalizeRunningTime;
    }
}
