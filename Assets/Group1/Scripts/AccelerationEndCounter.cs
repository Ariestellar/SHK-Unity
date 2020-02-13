using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AccelerationEndCounter : MonoBehaviour
{ 
    [SerializeField] private float _bonusExpirationTime;  
    [SerializeField] private UnityEvent _slowing;
    [SerializeField] private List<float> _currentRunnungBonusTimers;

    private float _currentTime;   

    private void Update()
    {
        ReduceTimersAllRunnungBonuses();
    }

    public void LaunchTimer()
    {        
        _currentTime = _bonusExpirationTime;
        _currentRunnungBonusTimers.Add(_currentTime);
    }

    private void ReduceTimersAllRunnungBonuses()
    {       
        for (int i = 0; i < _currentRunnungBonusTimers.Count; i++)
        {
            if (_currentRunnungBonusTimers[i] != 0)
            {
                _currentRunnungBonusTimers[i] -= Time.deltaTime;
                if (_currentRunnungBonusTimers[i] < 0)
                {
                    _slowing?.Invoke();
                    _currentRunnungBonusTimers.RemoveAt(i);
                }
            }            
        } 
    }
}
