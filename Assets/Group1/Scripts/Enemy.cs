using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private UnityEvent _deathing;
    public event UnityAction Deathing
    {
        add => _deathing.AddListener(value);
        remove => _deathing.RemoveListener(value);
    }
    
    public void Death()
    {
        _deathing.Invoke();
        _deathing.RemoveAllListeners();
        Destroy(gameObject);
    }
}
