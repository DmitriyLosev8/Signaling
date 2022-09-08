using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _speedOfChageVolume;
    [SerializeField] private Signaling _signaling;

    private float _runningTime;
    private float _targetValueOfVolume = 1f;
    private float _normalizeRunningTime;

    private void Start()
    {
        StartCoroutine(ChangeVolume());
    }



    private IEnumerator ChangeVolume()
    {
        float TargetValueOfVolume = 1;
        
        if (_signaling.IsThiefInSide == true)
        {   
            while (_audioSource.volume < _targetValueOfVolume)
            {
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, TargetValueOfVolume, _speedOfChageVolume * Time.deltaTime);
                Debug.Log(_audioSource.volume);

                if (_signaling.IsThiefInSide == false)
                {
                    while (_audioSource.volume > 0)
                    {
                        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, - TargetValueOfVolume, _speedOfChageVolume * Time.deltaTime);
                        Debug.Log(_audioSource.volume);
                        yield return null;
                    }
                }
                yield return null;
            }
        }
        else
        {
            while (_audioSource.volume > 0)
            {
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, - TargetValueOfVolume, _speedOfChageVolume * Time.deltaTime);
                Debug.Log(_audioSource.volume);
                yield return null;
            }
        }

        //if (_signaling.IsThiefInSide == true)
        //{

        //    RaiseVolume();

        //}
        //else
        //{
        // DowngradeVolume();
        //}

        //if (_signaling.IsThiefInSide == false)
        //{
        //    while (_audioSource.volume > 0)
        //    {
        //        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, -_targetValueOfVolume, _speedOfChageVolume * Time.deltaTime);
        //        Debug.Log(_audioSource.volume);
        //        yield return null;
        //    }
    

        // for (int i = 0; i < 10000; i++)
        // {
        //_audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetValueOfVolume, _speedOfChageVolume * Time.deltaTime);
        //Debug.Log(_audioSource.volume);
        //yield return null;
        // }
        // }


        // if (_signaling.IsThiefInSide == false)
        //{
        //    while (_audioSource.volume > 0)
        //    {
        //        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume,  -_targetValueOfVolume, _timeToRichMaxVolume * Time.deltaTime);
        //        yield return null;
        //    }
        //}






        //float TargetValueOfVolume = 1f;

        //    if (_signaling.IsThiefOutSide == false)
        //    {
        //        RaiseVolume();
        //        yield return new WaitWhile(() => _runningTime <= _timeToRichMaxVolume);
        //    }

        //    if (_signaling.IsThiefOutSide == true)
        //    {
        //        if (_runningTime > _timeToRichMaxVolume)
        //        {
        //            _runningTime = _timeToRichMaxVolume;
        //            DowngradeVolume();
        //        }
        //        else
        //        {
        //            DowngradeVolume();
        //        }
        //    }
        //}

        //private void DowngradeVolume()
        //{


        //    _runningTime -= Time.deltaTime;
        //    _normalizeRunningTime = _runningTime / _timeToRichMaxVolume;
        //    _audioSource.volume = _targetValueOfVolume * _normalizeRunningTime;
        //}


    }
   
    private IEnumerator RaiseVolume()
    {
        float TargetValueOfVolume = 1;

        while (_audioSource.volume < _targetValueOfVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, TargetValueOfVolume, _speedOfChageVolume * Time.deltaTime);
            Debug.Log(_audioSource.volume);

            if (_signaling.IsThiefInSide == false)
            {
                DowngradeVolume();
            }
            yield return null;
        }
    }

    private IEnumerator DowngradeVolume()
    {
        float TargetValueOfVolume = 0;

        while (_audioSource.volume > 0)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, TargetValueOfVolume, _speedOfChageVolume * Time.deltaTime);
            Debug.Log(_audioSource.volume);
            yield return null;
        }
    }
}
