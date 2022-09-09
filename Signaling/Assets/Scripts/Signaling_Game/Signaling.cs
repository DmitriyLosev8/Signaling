using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{
    [SerializeField] private UnityEvent _thiefInside;
    [SerializeField] private AudioSource _audioSource;

    public bool IsThiefInSide { get; private set; } = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            IsThiefInSide = true;
            _thiefInside.Invoke();    
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            IsThiefInSide = false;
        }
    }
}
