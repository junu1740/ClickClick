using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class Coroutine : MonoBehaviour
{

    float timer;
    public void Start()
    {
        StartCoroutine(TimerCoroutine());
    }

     IEnumerator TimerCoroutine()
    {
        int counter = 0;
        while (true)
        {
                Debug.Log(counter);
            counter++;
            yield return new WaitForSeconds(1);
        }

    }
}
