using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class States : MonoBehaviour
{
    [SerializeField]
    private GameObject _instructions;
    [SerializeField]
    private GameObject _instructionsText;
    [SerializeField]
    private GameObject _regionSelect;
    [SerializeField]
    private GameObject _game;
    [SerializeField]
    private Image _currentStateSprite;
    [SerializeField]
    private List<StatesSO> _midwestStates = new List<StatesSO>();
    [SerializeField]
    private List<StatesSO> _northeastStates = new List<StatesSO>();
    [SerializeField]
    private List<StatesSO> _southeastStates = new List<StatesSO>();
    [SerializeField]
    private List<StatesSO> _southwestStates = new List<StatesSO>();
    [SerializeField]
    private List<StatesSO> _westStates = new List<StatesSO>();
    [SerializeField]
    private GameObject[] _answers = new GameObject [4];
    [SerializeField]
    private List<Transform> _answerStartingPosition = new List<Transform>();
    [SerializeField]
    private List<StatesSO> _tempList = new List<StatesSO>();
    
    [SerializeField]
    private List<StatesSO> _currentSateRegion = new List<StatesSO>();
    private string _currentRegionName = "";
    private int _currentIndex;

    private void Start()
    {
        _currentIndex = 0;
        //ChooseState();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            NextQuestion();
        }
    }

    private void ChooseState()
    {
        switch (_currentRegionName)
        {
            case "Midwest":
                _currentSateRegion = _midwestStates;
                break;
            case "Northeast":
                _currentSateRegion = _northeastStates;
                break;
            case "Southeast":
                _currentSateRegion = _southeastStates;
                break;
            case "Southwest":
                _currentSateRegion = _southwestStates;
                break;
            case "West":
                _currentSateRegion = _westStates;
                break;
            default:
                Debug.Log("The current region is not valid");
                break;
        }

        Shuffle(_currentSateRegion);
        SetStateNames();
    }

    public void Shuffle(List<StatesSO> states)
    {
        var count = states.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = Random.Range(i, count);
            var tmp = states[i];
            states[i] = states[r];
            states[r] = tmp;
        }
    }

    public void Shuffle(GameObject []states)
    {
        var count = states.Length;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = Random.Range(i, count);
            var tmp = states[i];
            states[i] = states[r];
            states[r] = tmp;
        }
    }

    public void Shuffle(string[] states)
    {
        var count = states.Length;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = Random.Range(i, count);
            var tmp = states[i];
            states[i] = states[r];
            states[r] = tmp;
        }
    }

    private void SetCurrentState()
    {
        
    }

    public void SetStateNames()
    {
        TMP_Text answerText = null;
        string[] shuffledAnswers = new string [4]; 
        
        // Clear the temp list
        _tempList.Clear();
        // Copy the current region states to a temp list that can be shuffled
        foreach (var state in _currentSateRegion)
        {
            _tempList.Add(state);
        }
        // Assign the first element of the the state names to the current state index of the current state region list
        // Assign the correct sprite to the image
        answerText = _answers[0].GetComponentInChildren<TMP_Text>();
        answerText.text = _currentSateRegion[_currentIndex].GetStateName();
        _currentStateSprite.sprite = _currentSateRegion[_currentIndex].GetStateSprite();
        // find the current state in the temp state list and remove it so it cannot be duplicated
        for (int i = 0; i < _tempList.Count; i++)
        {
            if(_tempList[i].GetStateName() == answerText.text)
            {
                _tempList.RemoveAt(i);
                break;
            }
        }
        // Shuffle the temp list to get a random order of names
        Shuffle(_tempList);
        // Assign the last three elemnet to the rest of the state names array
        for (int i = 0; i <= 3; i++)
        {
            if (i == 0)
            {
                shuffledAnswers[0] = _currentSateRegion[_currentIndex].GetStateName();
                continue;
            }
                shuffledAnswers[i] =  _tempList[i - 1].GetStateName();
        }
        Shuffle(shuffledAnswers);
        for (int i = 0; i < _answers.Length; i++)
        {
            answerText = _answers[i].GetComponentInChildren<TMP_Text>();
            answerText.text = shuffledAnswers[i];
        }
    }

    public string GetCurrentState()
    {
        return _currentSateRegion[_currentIndex].GetStateSprite().name;
    }

    public void NextQuestion()
    {
        _currentIndex++;
        if(_currentIndex > _currentSateRegion.Count)
        {
            GameManager.Instance.ShowResults();
        }
        else
        {
            //foreach (var answer in _answers)
            //{
            //    answer.GetComponent<DraggableItem>().ReturnHome();
            //}
            SetStateNames();
        }
    }

    public void AssignRegion(string region)
    {
        _currentRegionName = region;
        _instructions.SetActive(false);
        ChooseState();
        _game.SetActive(true);
    }

    public void SelectRegion()
    {
        _regionSelect.SetActive(true);
        _instructionsText.SetActive(false);
    }
}
