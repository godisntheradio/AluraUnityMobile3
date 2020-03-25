using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnalogStick : MonoBehaviour, IDragHandler
{
    [SerializeField]
    private RectTransform BG;
    [SerializeField]
    private RectTransform Stick;
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 mousePos = GetMousePosition(eventData);
        MoveStick(mousePos);
        Debug.Log(mousePos);
    }

    private void MoveStick(Vector2 mousePos)
    {
        Stick.localPosition = mousePos;
    }

    private Vector2 GetMousePosition(PointerEventData eventData)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(BG, eventData.position, eventData.enterEventCamera, out pos);
        return pos; 
    }
}
