using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private Vector3 _snapPosition;
    [SerializeField]
    private Vector3 _startingPosition;
    [SerializeField]
    private Image _image;

    private void OnEnable()
    {
        _image = GetComponent<Image>();
        if (_image == null)
            Debug.LogError("This Draggable object does not have an Image.");
        _snapPosition = _image.rectTransform.localPosition;
        _startingPosition = _image.rectTransform.localPosition;
    }

    public void ResetPosition()
    {
        _image.rectTransform.localPosition = _snapPosition;
        _image.raycastTarget = true;
    }

    public Vector3 GetHomePosition()
    {
        return _startingPosition;
    }

    public void SetPosition(Vector3 newPosition)
    {
        _snapPosition = newPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ResetPosition();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _image.raycastTarget = false;
    }
}
