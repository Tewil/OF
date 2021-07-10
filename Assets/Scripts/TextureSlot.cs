using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextureSlot : MonoBehaviour, IDropHandler
{
    public static bool itsOnDrop;
    public static int seed = 0;

    public void OnDrop(PointerEventData eventData) {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            itsOnDrop = true;
            if (EarthSeedDrag.active == true){
                seed = 1;
            }
            if (FireSeedDrag.active == true){
                seed = 2;
            }
            if (WaterSeedDrag.active == true){
                seed = 3;
            }
            if (WindSeedDrag.active == true){
                seed = 4;
            }

    }
}
