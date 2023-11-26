using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/State")]
public class StatesSO : ScriptableObject
{
    [SerializeField]
    private string _stateName;
    [SerializeField]
    private Sprite _stateSprite;

    public string GetStateName()
    {
        return _stateName;
    }

    public Sprite GetStateSprite()
    {
        return _stateSprite;
    }
}
