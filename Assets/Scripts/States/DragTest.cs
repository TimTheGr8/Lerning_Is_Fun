using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragTest : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Image _image;
    public void OnBeginDrag(PointerEventData eventData)
    {
        _image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _image.raycastTarget = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        if (_image == null)
            Debug.LogError("This Draggable object does not have an Image.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
