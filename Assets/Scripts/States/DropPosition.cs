using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropPosition : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private States _states;

    private Image _image;
    private string _stateText;
    private GameObject _dropPositionText;

    private void Start()
    {
        _dropPositionText = GetComponentInChildren<TMP_Text>().gameObject;
        if (_dropPositionText == null)
            Debug.LogError("There is no drop location text.");

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
        string playerAnswer = eventData.pointerDrag.GetComponentInChildren<TMP_Text>().text;
        if ( playerAnswer == _stateText)
        {
            eventData.pointerDrag.GetComponent<DraggableItem>().SetPosition(_image.rectTransform.localPosition);
        }
    }

    private void AssignState()
    {
        _stateText = _states.GetCurrentState();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _dropPositionText.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _dropPositionText.SetActive(true);
    }
}