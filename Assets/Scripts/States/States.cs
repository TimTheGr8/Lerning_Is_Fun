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
        //List<StatesSO> stateRegion = null;

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
        SetCurrentState();
    }
    //TODO: Fix this to work with the states
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

    private void SetCurrentState()
    {
        _currentStateSprite.sprite = _currentSateRegion[_currentIndex].GetStateSprite();
        _stateNames[0].text = _currentSateRegion[_currentIndex].GetStateName();
        for (int i = 1; i < 4; i++)
        { //TODO: Need to check the current name against the first one in the list
            // Also need to randomize the order of the answers 
            var rand = Random.Range(0, _currentSateRegion.Count);
            for (int j = 0; j < _stateNames.Count; j++)
            {
                if (_stateNames[i] == _stateNames[j])
                {
                    rand = Random.Range(0, _currentSateRegion.Count);
                    continue;
                }
            }
            _stateNames[i].text = _currentSateRegion[rand].GetStateName();
        }
    }

    public string GetCurrentState()
    {
        return _currentSateRegion[_currentIndex].GetStateSprite().name;
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
