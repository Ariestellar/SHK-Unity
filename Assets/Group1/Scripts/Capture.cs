using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Capture : MonoBehaviour
{    
    [SerializeField] private List<ObjectsToCapture> _gameObjects;  

    private void Update()
    {
        CheckingDistanceToObject(_gameObjects);
    }
    
    private void CheckingDistanceToObject(List<ObjectsToCapture> gameObjectList)
    {
        foreach (var gameObject in gameObjectList)
        {
            if (Vector3.Distance(transform.position, gameObject.transform.position) < 0.2f)
            {
                gameObject.Catch();
                gameObjectList.Remove(gameObject);
            }            
        }
    }    
}
