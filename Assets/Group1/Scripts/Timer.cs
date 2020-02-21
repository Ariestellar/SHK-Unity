using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    private Coroutine _timerRoutine;
    private float _pastTime;

    public void StartTimer(float duration, UnityEvent onEnd = null)
    {
        if (_timerRoutine != null)
            StopCoroutine(_timerRoutine);

        _timerRoutine = StartCoroutine(Run(duration, onEnd));
    }  

    private IEnumerator Run(float duration, UnityEvent onEnd)
    {
        _pastTime = 0.0f;
        while (_pastTime < duration)
        {
            _pastTime += Time.deltaTime;            
            yield return null;
        }

        onEnd?.Invoke();
    }
}
