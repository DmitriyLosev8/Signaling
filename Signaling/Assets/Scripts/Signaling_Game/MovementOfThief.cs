using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOfThief : MonoBehaviour
{
    [SerializeField] private float _speed;
   
    void Update()
    {
        if (Input.GetKey(KeyCode.D) == true)
        {
            transform.Translate(_speed * Time.deltaTime,0,0);
        }


        if (Input.GetKey(KeyCode.A) == true)
        {
            transform.Translate(_speed * Time.deltaTime  * - 1, 0, 0);
        }
    }
}
