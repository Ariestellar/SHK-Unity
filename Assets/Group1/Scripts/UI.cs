using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject _finischPanel;
    [SerializeField] private DeathCounter _deathCounter;

    private void Awake()
    {
        _deathCounter.OnAllEnemiesDead += () => ShowFinischPanel();
    }

    private void ShowFinischPanel()
    {
        _finischPanel.SetActive(true);
    }
}
