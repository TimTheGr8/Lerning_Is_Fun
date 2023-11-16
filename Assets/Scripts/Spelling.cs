using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Spelling : MonoBehaviour
{
    [SerializeField]
    private GameObject _instructions;
    [SerializeField]
    private GameObject _game;
    [SerializeField]
    private TMP_InputField _playerInput; 
    [SerializeField]
    private AudioSource _audio;
    [SerializeField]
    private TMP_Text _feedbackText;
    [SerializeField]
    private TMP_Text _wordNumberText;
    [SerializeField]
    private GameObject _checkWordButton;
    [SerializeField]
    private GameObject _nextWordButton;
    [SerializeField]
    private GameObject _playWordButton;
    [SerializeField]
    private List<AudioClip> _words = new List<AudioClip>();

    private AudioClip _audioClip;
    private string _playerAnswer;
    private string _currentWord;
    private int _wordNumber = 0;
    [SerializeField]
    private List<AudioClip> _wordList = new List<AudioClip>();

    private void Start()
    {
        //ChooseWord();
        GenerateWordList();
    }


    public void ChooseWord()
    {
        if (_wordNumber < 10)
            _wordNumber++;
        else
            FinishGame();

        _feedbackText.text = null;
        _playerInput.text = null;
        _nextWordButton.SetActive(false);
        _playWordButton.SetActive(true);
        _checkWordButton.SetActive(true);
        _wordNumberText.text = _wordNumber.ToString();

        _audioClip = _words[Random.Range(0, _words.Count)];
        _currentWord = _audioClip.name;
        StartCoroutine(WordPause());
    }

    private void GenerateWordList()
    {
        int randIndex = 0;

        for (int i = 0; i < 10; i++)
        {
            randIndex = Random.Range(0, _words.Count);
            for (int j = 0; j < _wordList.Count; j++)
            {
                if (_wordList[j] == _words[randIndex])
                {
                    randIndex = Random.Range(0, _words.Count);
                    continue;
                }
            }
            _wordList.Add(_words[randIndex]);
        }
    }

    public void CheckWord()
    {
        _playWordButton.SetActive(false);
        _checkWordButton.SetActive(false);
        _nextWordButton.SetActive(true);

        _playerAnswer = _playerInput.text;
        if(_playerAnswer == _currentWord)
        {
            _feedbackText.text = "That is correct!";
        }
        else
        {
            _feedbackText.text = $"The correct spelling is {_currentWord}";
        }
    }

    public void PlayWord()
    {
        _audio.PlayOneShot(_audioClip);
    }

    private void FinishGame()
    {
        Debug.Log("The game is over.");
    }

    IEnumerator WordPause()
    {
        yield return new WaitForSeconds(0.25f);
        PlayWord();
    }
}
