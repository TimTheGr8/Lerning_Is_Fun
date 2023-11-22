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

    [SerializeField]
    private List<string> _wordSpelling = new List<string>();
    
    public AudioClip _spokenWord;

    public AudioClip GetAudioClip()
    {
        return _spokenWord;
    }

    public List<string> GetSpelling()
    {
        return _wordSpelling;
    }
}
