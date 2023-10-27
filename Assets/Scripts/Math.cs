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
    private int _minValue = 0;
    [SerializeField]
    private int _maxValue = 50;

    private int _number1;
    private int _number2;
    private int _answer;
    private int _playerAnswer;
    private enum Operator
    {
        Addition,
        Subtraction,
        Division,
        Multiplication
    }
    private string _currentOperation;

    private void Start()
    {
        //_currentOperation = Operator.Addition;
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

    private void GenerateEquation()
    {
        GenerateNumbers();
        ///TODO: Check the operation and ensure the answer will be positive and division will be and int using modulo

        AssignNumbers();
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
            _feedbackText.text = "CORRECT";
        }
        else
        {
            _feedbackText.text = $"Incorrect. The correct answer is {_answer}.";
        }
    }

    public void SetOperation()
    {
        switch (_operatorDropDown.options[_operatorDropDown.value].text)
        {
            case "Addition":
                //_currentOperation = Operator.Addition;
                _currentOperation = "Addition";
                _operatorText.text = "+";
                break;
            case "Subtraction":
                //_currentOperation = Operator.Subtraction;
                _currentOperation = "Subtraction";
                _operatorText.text = "-";
                break;
            case "Multiplication":
                //_currentOperation = Operator.Multiplication;
                _currentOperation = "Multiplication";
                _operatorText.text = "x";
                break;
            case "Division":
                //_currentOperation = Operator.Division;
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
