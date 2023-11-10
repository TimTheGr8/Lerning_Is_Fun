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
    private string _itemText;

    private void Start()
    {
        _image = GetComponent<Image>();
        if (_image == null)
            Debug.LogError("The Drop Posiiton does not have an image.");

        PickItem();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.name == _itemText)
        {
            eventData.pointerDrag.GetComponent<DraggableItem>().SetPosition(_image.rectTransform.localPosition);
        }
    }

    private void PickItem()
    {
        int rand = Random.Range(0, _itemList.Count);
        _itemText = _itemList[rand];
        _itemText = "California";
        //_itemTextField.text = _itemText;
    }
}