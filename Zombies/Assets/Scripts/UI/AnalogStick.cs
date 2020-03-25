using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AnalogStick : MonoBehaviour, IDragHandler
{
    [SerializeField]
    private RectTransform BG;
    [SerializeField]
    private RectTransform Stick;
    [SerializeField]
    private OnChangePosition OnChangePosition;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 mousePos = GetMousePosition(eventData);
        Vector2 clampedPos = GetClampedPos(mousePos);
        MoveStick(clampedPos);
        Debug.Log(clampedPos);
    }

    private Vector2 GetClampedPos(Vector2 mousePos)
    {
        Vector2 clamped = mousePos / GetExtends(BG.rect);
        if (clamped.magnitude > 1)
        {
            clamped = clamped.normalized;
        }
        return clamped;
    }

    private void MoveStick(Vector2 mousePos)
    {
        Stick.localPosition = mousePos * GetExtends(BG.rect);
        OnChangePosition.Invoke(mousePos);
    }
    private Vector2 GetExtends(Rect image)
    {
        return new Vector2(BG.rect.width, BG.rect.height) / 2;
    }
    private Vector2 GetMousePosition(PointerEventData eventData)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(BG, eventData.position, eventData.enterEventCamera, out pos);
        return pos; 
    }
}
[Serializable]
public class OnChangePosition : UnityEvent<Vector2>
{

}