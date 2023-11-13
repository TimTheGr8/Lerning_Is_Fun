using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropPosition : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private TMP_Text _itemTextField;
    [SerializeField]
    private List<string> _itemList = new List<string>();
    private Image _image;
    private string _stateText;
    [SerializeField]
    private States _states;

    private void Start()
    {
        _states = GetComponentInParent<States>();
        if (_states == null)
            Debug.LogError("There is no State script.");

        _image = GetComponent<Image>();
        if (_image == null)
            Debug.LogError("The Drop Posiiton does not have an image.");

        AssignState();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.name == _stateText)
        {
            eventData.pointerDrag.GetComponent<DraggableItem>().SetPosition(_image.rectTransform.localPosition);
        }
    }

    private void AssignState()
    {
        _stateText = _states.GetCurrentState();
    }
}