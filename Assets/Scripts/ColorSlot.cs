using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColorSlot : MonoBehaviour, IDropHandler
{
    public static bool itsOnDropColor;
    public static int seedColor;

    void Start(){
        itsOnDropColor = false;
        seedColor = 0;
    }

    public void OnDrop(PointerEventData eventData) {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            itsOnDropColor = true;
            if (EarthSeedDrag.earthActive == true || EarthSeedDrag1.earthActive1 == true || EarthSeedDrag2.earthActive2 == true || EarthSeedDrag3.earthActive3 == true){
                seedColor = 1;
            }
            if (FireSeedDrag.fireActive == true || FireSeedDrag1.fireActive1 == true || FireSeedDrag2.fireActive2 == true || FireSeedDrag3.fireActive3 == true){
                seedColor = 2;
            }
            if (WaterSeedDrag.waterActive == true || WaterSeedDrag1.waterActive1 == true || WaterSeedDrag2.waterActive2 == true || WaterSeedDrag3.waterActive3 == true){
                seedColor = 3;
            }
            if (WindSeedDrag.windActive == true || WindSeedDrag1.windActive1 == true || WindSeedDrag2.windActive2 == true || WindSeedDrag3.windActive3 == true){
                seedColor = 4;
            }

    }
}
