using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Spelling Word")]
public class TestSO : ScriptableObject
{
    [SerializeField]
    private string _spelling1;
    [SerializeField]
    private string _spelling2;
    [SerializeField]
    private string _word;
    
    public AudioClip _spokenWord;

    public AudioClip GetAudioClip()
    {
        return _spokenWord;
    }
}
