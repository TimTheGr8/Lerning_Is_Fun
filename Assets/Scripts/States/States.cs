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
    private Image _currentState;
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


    private string _currentRegion = "";

    private void Start()
    {
        //ChooseState();
    }

    private void ChooseState()
    {
        List<StatesSO> stateRegion = null;

        switch (_currentRegion)
        {
            case "Midwest":
                stateRegion = _midwestStates;
                break;
            case "Northeast":
                stateRegion = _northeastStates;
                break;
            case "Southeast":
                stateRegion = _southeastStates;
                break;
            case "Southwest":
                stateRegion = _southwestStates;
                break;
            case "West":
                stateRegion = _westStates;
                break;
            default:
                Debug.Log("The current region is not valid");
                break;
        }

        int rand = Random.Range(0, stateRegion.Count);
        /////////////////   Fix this to get the current srpite from the state scriptable object   \\\\\\\\\\\\\\\\\\\\\\\\\\\
        //_currentState.sprite = stateRegion[rand];
    }

    public string GetCurrentState()
    {
        string newState = _currentState.sprite.name;
        return newState;
    }

    public void AssignRegion(string region)
    {
        _currentRegion = region;
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
