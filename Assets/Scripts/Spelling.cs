using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    private List<TestSO> _words = new List<TestSO>();
    [SerializeField]
    private List<TMP_Text> _answerButtonsText = new List<TMP_Text>();

    private AudioClip _audioClip;
    private string _playerAnswer;
    private string _currentWord;
    private int _wordNumber = 1;
    [SerializeField]
    private List<TestSO> _wordListTest = new List<TestSO>();
    [SerializeField]
    private List<AudioClip> _wordList = new List<AudioClip>();
    private TestSO _currentWordSpelling;

    private void Start()
    {
        GenerateWordList();
    }


    public void NextWord()
    {
        if (_wordNumber < 10)
            _wordNumber++;
        else
            FinishGame();

        _wordNumberText.text = _wordNumber.ToString();
        _audioClip = _wordListTest[_wordNumber - 1].GetAudioClip();
        _currentWordSpelling = _wordListTest[_wordNumber - 1];
        SetWord();
    }

    private void SetWord()
    {
        _feedbackText.text = null;
        _playerInput.text = null;
        _nextWordButton.SetActive(false);
        _playWordButton.SetActive(true);
        _currentWord = _audioClip.name;
        StartCoroutine(WordPause());
        AssignButtonText();
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
            _wordListTest.Add(_words[randIndex]);
        }
        _audioClip = _wordListTest[0].GetAudioClip();
        _currentWordSpelling = _wordListTest[0];
        SetWord();
    }

    private void AssignButtonText()
    {
        List<string> spelling = _wordListTest[_wordNumber - 1].GetSpelling();

        for (int i = 0; i < _answerButtonsText.Count; i++)
        {
            _answerButtonsText[i].text = spelling[i];
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
