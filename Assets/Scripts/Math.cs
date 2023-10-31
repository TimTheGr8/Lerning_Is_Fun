using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Math : MonoBehaviour
{
    [SerializeField]
    GameObject _operationSelectScreen;
    [SerializeField]
    TMP_Dropdown _operatorDropDown;
    [SerializeField]
    GameObject _mathGame;
    [SerializeField]
    private TMP_Text _questionNumberText;
    [SerializeField]
    private TMP_Text _number1Text;
    [SerializeField]
    private TMP_Text _number2Text;
    [SerializeField]
    private TMP_Text _operatorText;
    [SerializeField]
    private TMP_Text _feedbackText;
    [SerializeField]
    private TMP_InputField _answerField;
    [SerializeField]
    private GameObject _nextQuestionButton;
    [SerializeField]
    private int _minValue = 0;
    [SerializeField]
    private int _maxValue = 50;

    private int _number1;
    private int _number2;
    private int _answer;
    private int _playerAnswer;
    private int _questionNumber = 0;
    private int _correctAnswers;
    private string _currentOperation;

    private void Start()
    {
        _correctAnswers = 0;
        _currentOperation = "Addition";
        _mathGame.SetActive(false);
        _operationSelectScreen.SetActive(true);
        _feedbackText.text = "Enter your answer and press the Enter key";
        GenerateEquation();
    }

    private void GenerateNumbers()
    {
        _number1 = Random.Range(_minValue, _maxValue + 1);
        _number2 = Random.Range(_minValue, _maxValue + 1);
    }

    public void GenerateEquation()
    {
        _questionNumber++;
        if (_questionNumber > 10)
        {
            // Do the results stuff
            GameManager.Instance.ShowResults();
        }
        else
        {
            _nextQuestionButton.SetActive(false);
            _answerField.gameObject.SetActive(true);
            _answerField.text = null;
            _answerField.Select();
            _feedbackText.text = "Enter your answer and press the Enter key";
            _questionNumberText.text = $"Question {_questionNumber})";
            GenerateNumbers();
            switch (_currentOperation)
            {
                case "Addition":
                    AdditionEquation();
                    break;
                case "Subtraction":
                    SubtractionEquation();
                    break;
                case "Division":
                    DivisionEquation();
                    break;
                case "Multiplication":
                    MultiplicationEquation();
                    break;
                default:
                    Debug.LogError("There is no operation selected.");
                    break;
            }
            AssignNumbers();
        }
    }

    private void AdditionEquation()
    {
        _answer = _number1 + _number2;
    }

    private void SubtractionEquation()
    {
        if(_number1 < _number2)
        {
            int tempNumber = _number1;
            _number1 = _number2;
            _number2 = tempNumber;
        }
        _answer = _number1 - _number2;
    }

    private void MultiplicationEquation()
    {
        _answer = _number1 * _number2;
    }

    private void DivisionEquation()
    {
        if (_number2 > 1)
        {
            _number1 = _number2 * Random.Range(1, 11);
            AssignNumbers();
        }
        else
        {
            GenerateEquation();
        }
    }

    private void AssignNumbers()
    {
        _number1Text.text = _number1.ToString();
        _number2Text.text = _number2.ToString();
    }

    public void CheckAnswer()
    {
        _playerAnswer = int.Parse(_answerField.text);

        if (_playerAnswer == _answer)
        {
            _correctAnswers++;
            _feedbackText.text = "CORRECT";
        }
        else
        {
            _feedbackText.text = $"Incorrect. The correct answer is {_answer}.";
        }
        _answerField.gameObject.SetActive(false);
        _nextQuestionButton.SetActive(true);
    }

    public void SetOperation()
    {
        switch (_operatorDropDown.options[_operatorDropDown.value].text)
        {
            case "Addition":
                _currentOperation = "Addition";
                _operatorText.text = "+";
                break;
            case "Subtraction":
                _currentOperation = "Subtraction";
                _operatorText.text = "-";
                break;
            case "Multiplication":
                _currentOperation = "Multiplication";
                _operatorText.text = "x";
                break;
            case "Division":
                _currentOperation = "Division";
                _operatorText.text = "/";
                break;
            default:
                Debug.LogError("The selection is not valid.");
                break;
        }
    }

    public void StartMathGame()
    {
        _operationSelectScreen.SetActive(false);
        _mathGame.SetActive(true);
    }
}
