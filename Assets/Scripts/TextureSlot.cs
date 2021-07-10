using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextureSlot : MonoBehaviour, IDropHandler
{
    public static bool itsOnDrop;
    public static bool active;

    public void OnDrop(PointerEventData eventData) {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            itsOnDrop = true;
            active = true;
    }
}

