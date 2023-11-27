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
    private List<TMP_Text> _stateNames = new List<TMP_Text>();
    [SerializeField]
    private List<Transform> _stateNameStartingPosition = new List<Transform>();
    [SerializeField]
    private List<StatesSO> _tempList = new List<StatesSO>();
    
    private List<StatesSO> _currentSateRegion = new List<StatesSO>();
    private string _currentRegionName = "";
    private int _currentIndex;

    private void Start()
    {
        _currentIndex = 0;
        //ChooseState();
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

    //public void Shuffle(List<string> states)
    //{
    //    var count = states.Count;
    //    var last = count - 1;
    //    for (var i = 0; i < last; ++i)
    //    {
    //        var r = Random.Range(i, count);
    //        var tmp = states[i];
    //        states[i] = states[r];
    //        states[r] = tmp;
    //    }
    //}

    private void SetCurrentState()
    {
        
    }

    public void SetStateNames()
    {
        _tempList = _currentSateRegion;
        Shuffle(_tempList);
        // Assign Random names to the answers in the game.
        for (int i = 0; i < _stateNames.Count; i++)
        {
            _stateNames[i].text = _tempList[i].GetStateName();
        }

    }

    public string GetCurrentState()
    {
        return _currentSateRegion[_currentIndex].GetStateSprite().name;
    }

    public void NextQuestion()
    {

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
