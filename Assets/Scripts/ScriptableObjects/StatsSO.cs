using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Stats")]
public class StatsSO : ScriptableObject
{
    [SerializeField]
    private string _currentSubject;

    private int _correctAnswers;

}
