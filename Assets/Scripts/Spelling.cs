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
    private AudioSource _audio;
    [SerializeField]
    private TMP_Text _feedbackText;
    [SerializeField]
    private TMP_Text _wordNumberText;
    [SerializeField]
    private GameObject _nextWordButton;
    [SerializeField]
    private GameObject _playWordButton;
    [SerializeField]
    private List<WordSO> _words = new List<WordSO>();
    [SerializeField]
    private List<GameObject> _answerButtons = new List<GameObject>();
    [SerializeField]
    private List<TMP_Text> _answerButtonsText = new List<TMP_Text>();

    private AudioClip _audioClip;
    private string _playerAnswer;
    private string _currentWord;
    private int _wordNumber = 1;
    private List<WordSO> _wordList = new List<WordSO>();
    private WordSO _currentWordSpelling;

    private void OnEnable()
    {
        _wordNumber = 1;
        _game.SetActive(false);
        _instructions.SetActive(true);
        _wordNumberText.text = _wordNumber.ToString();
    }

    public void NextWord()
    {
        if (_wordNumber < 10)
        {
            _wordNumber++;

            _wordNumberText.text = _wordNumber.ToString();
            _audioClip = _wordList[_wordNumber - 1].GetAudioClip();
            _currentWordSpelling = _wordList[_wordNumber - 1];
            SetWord();
        }
        else
        {
            FinishGame();
            return;
        }
    }

    private void SetWord()
    {
        _feedbackText.text = null;
        _nextWordButton.SetActive(false);
        _playWordButton.SetActive(true);
        foreach (var button in _answerButtons)
        {
            button.SetActive(true);
        }
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
            _wordList.Add(_words[randIndex]);
        }
        _audioClip = _wordList[0].GetAudioClip();
        _currentWordSpelling = _wordList[0];
        SetWord();
    }

    private void AssignButtonText()
    {
        List<string> spelling = _wordList[_wordNumber - 1].GetSpelling();
        Shuffle(spelling);

        for (int i = 0; i < _answerButtonsText.Count; i++)
        {
            _answerButtonsText[i].text = spelling[i];
        }
    }

    public void Shuffle(List<string> words)
    {
        var count = words.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = Random.Range(i, count);
            var tmp = words[i];
            words[i] = words[r];
            words[r] = tmp;
        }
    }

    public void CheckWord(int buttonNumber)
    {
        foreach (var button in _answerButtons)
        {
            button.SetActive(false);
        }
        _playWordButton.SetActive(false);
        _nextWordButton.SetActive(true);

        _playerAnswer = _answerButtonsText[buttonNumber].text;
        if(_playerAnswer == _currentWord)
        {
            _feedbackText.text = "That is correct!";
            GameManager.Instance.AddCorrectAnswer();
        }
        else
        {
            _feedbackText.text = $"The correct spelling is {_currentWord}";
            GameManager.Instance.AddWrongAnswer();
        }
    }

    public void StartGame()
    {
        _instructions.SetActive(false);
        _game.SetActive(true);
        GenerateWordList();
    }

    public void PlayWord()
    {
        StartCoroutine(WordPause());
        // TODO: Fix this because you are a dumb ass
        //_audio.PlayOneShot(_audioClip);
        //Audio.Instance.PlayOneShot(_audioClip);
    }

    private void FinishGame()
    {
        GameManager.Instance.CalculateResults();
        GameManager.Instance.ShowResults();
    }

    IEnumerator WordPause()
    {
        Audio.Instance.SetMusicVolume(0.25f);
        yield return new WaitForSeconds(0.25f);
        //PlayWord();
        Audio.Instance.PlayOneShot(_audioClip);
        yield return new WaitForSeconds(0.75f);
        Audio.Instance.SetMusicVolume(1.0f);
    }
}
