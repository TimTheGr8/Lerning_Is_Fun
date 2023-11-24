using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Word")]
public class WordSO : ScriptableObject
{
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
