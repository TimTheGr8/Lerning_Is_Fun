using System.Collections;
using System.Collections.Generic;
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

    private string _currentSubject;
    private int _correctAnswers;
    private GameObject _currentScreen;

    private void OnEnable()
    {
        // Enable the title screen
        _currentScreen = _titleScreen;
        _currentScreen.SetActive(true);
    }

    private void Awake()
    {
        _instance = this;
        _currentSubject = "Math";
    }

    public void SetCurrentSubject(string subject)
    {
        PlayerPrefs.SetString("Subject", subject);
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
}
