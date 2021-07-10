using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColorSlot : MonoBehaviour, IDropHandler
{
    public static bool itsOnDrop;
    public static bool colorActive;

    public void OnDrop(PointerEventData eventData) {
        if (itsOnDrop == true) {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
        else {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            itsOnDrop = true;
            if (GlobalCount.count >= 3) {
            }
            else {
                GlobalCount.count++;
            }
        }
        colorActive = true;
    }
}
