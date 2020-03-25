using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectsToCapture : MonoBehaviour
{
    protected event Action _cathing;

    public event Action Catсhing
    {
        add => _cathing += value;
        remove => _cathing -= value;
    }

    public virtual void Catch()
    {

    }

    protected void Destruction()
    {
        _cathing?.Invoke();
        Destroy(gameObject);
    }
}
