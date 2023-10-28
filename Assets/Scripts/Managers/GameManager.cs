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
                Debug.LogError("GameManager is NULL");

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

    private string _currentGame;
    private int _totalMathQuestions;
    private int _correctMathQuestions;
    private int _totalSpellingQuestions;
    private int _correctSpellingQuestions;
    private int _totalStatesQuestions;
    private int _correctStatesQuestions;

    private void OnEnable()
    {
        // Enable the title screen
    }

    public void DisplayResults()
    {

    }

    public void AdjustResults(string subject, int correctAnswers)
    {
        switch (subject)
        {
            case "Math":
                // Do stuff here
                _totalMathQuestions += 10;
                _correctMathQuestions += correctAnswers;
                break;
            case "Spelling":
                // More stuff here
                _totalSpellingQuestions += 10;
                _correctSpellingQuestions += correctAnswers;
                break;
            case "States":
                _totalStatesQuestions += 10;
                _correctStatesQuestions += correctAnswers;
                // Last stuff 
                break;
            default:
                break;
        }
    }
}
