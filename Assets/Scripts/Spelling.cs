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

    [SerializeField]
    private AudioClip _audioClip;
    private string _playerAnswer;
    private string _currentWord;
    private int _wordNumber = 0;

    private void Start()
    {
        ChooseWord();
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
        // Play the word after a brief pause
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
}
