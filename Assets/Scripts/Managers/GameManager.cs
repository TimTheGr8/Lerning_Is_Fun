using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameManager is NULL");
            }
            return _instance;
        }
    }

    [SerializeField]
    private GameObject _titleScreen;
    [SerializeField]
    private GameObject _gameSelectScreen;
    [SerializeField]
    private GameObject _resultsScreen;
    [SerializeField]
    private GameObject _mathScreen;
    [SerializeField]
    private GameObject _spellingScreen;
    [SerializeField]
    private GameObject _statesScreen;

    private GameObject _currentScreen;
    [SerializeField]
    private float _correctAnswers = 0;
    [SerializeField]
    private float _wrongAnswers = 0;
    [SerializeField]
    private float _totalAnswers = 0;
    private float _grandTotalAnswers = 0;
    private float _grandTotalCorrectAnswers = 0;
    private float _grandtotalpercent = 0f;

    private void OnEnable()
    {
        _currentScreen = _titleScreen;
        _currentScreen.SetActive(true);
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)))
        {
            SwitchScreen(_gameSelectScreen);
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void ShowResults()
    {
        _currentScreen.SetActive(false);
        _currentScreen = _resultsScreen;
        _currentScreen.SetActive(true);
    }

    public void SwitchScreen(GameObject game)
    {
        var oldScreen = _currentScreen;
        _currentScreen = game;
        oldScreen.SetActive(false);
        _currentScreen.SetActive(true);
    }

    public void AddCorrectAnswer()
    {
        _correctAnswers++;
        _grandTotalCorrectAnswers++;
        AddTotalAnswers();
    }

    public void AddWrongAnswer()
    {
        _wrongAnswers++;
        AddTotalAnswers();
    }

    private void AddTotalAnswers()
    {
        _totalAnswers++;
        _grandTotalAnswers++;
    }

    public void ClearAnswers()
    {
        _correctAnswers = 0;
        _wrongAnswers = 0;
        _totalAnswers = 0;
    }

    public void CalculateResults()
    {
        float percent = (_correctAnswers / _totalAnswers) * 100f;
        Stats.Instance.SetCurrentScore(percent);
    }

    public float CalculateTotalPercent()
    {
        float percent = (_grandTotalCorrectAnswers / _grandTotalAnswers) * 100f;
        return percent;
    }

    public void QuitGame()
    {
       Application.Quit();
    }
}
