using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _speedOfChageVolume;
    [SerializeField] private Signaling _signaling;

    private void Start()
    {
        StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        float TargetValueOfVolume = 1;
        bool Isplaing = true;

        while (Isplaing)
        {
            if (_signaling.IsThiefInSide == true)
            {
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, TargetValueOfVolume, _speedOfChageVolume * Time.deltaTime);
                yield return null;
            }

            if (_signaling.IsThiefInSide == false)
            {
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, - TargetValueOfVolume, _speedOfChageVolume * Time.deltaTime);
                yield return null;
            }
        }
    }
}
