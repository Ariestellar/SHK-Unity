using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AccelerationEndCounter : MonoBehaviour
{ 
    [SerializeField] private float _timeDefault;    
    [SerializeField] private List <float> _listAccelerationBonusCounter;

    private int _accelerationBonusCounter;
    private float _currentTime;
    private event SlowHandler _slowing;

    public delegate void SlowHandler();
    public event SlowHandler Slowing
    {
        add => _slowing += value;
        remove => _slowing -= value;
    }

    private void Update()
    {
        FinishAcceleration();
    }

    public void LaunchTimer()
    {      
        _accelerationBonusCounter += 1;        
        if (_accelerationBonusCounter > 1)
        {
            _listAccelerationBonusCounter.Add(_currentTime);
            _accelerationBonusCounter--;
        }
        _currentTime = _timeDefault;
    }

    private void FinishAcceleration()
    {
        if (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;            
        }
        else if(_currentTime < 0)
        {
            _slowing?.Invoke();
            
            if (_listAccelerationBonusCounter.Count != 0)
            {                
                _currentTime = _listAccelerationBonusCounter[_listAccelerationBonusCounter.Count - 1];                
                _listAccelerationBonusCounter.RemoveAt(_listAccelerationBonusCounter.Count - 1);                
            }
            else 
            {
                _currentTime = 0;                
            }
        }
    }
}
