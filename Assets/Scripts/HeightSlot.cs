using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HeightSlot : MonoBehaviour, IDropHandler
{
    public static bool itsOnDropHeight;
    public static int seedHeight;

    void Start(){
        itsOnDropHeight = false;
        seedHeight = 0;
    }

    public void OnDrop(PointerEventData eventData) {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            itsOnDropHeight = true;
            if (EarthSeedDrag.earthActive == true || EarthSeedDrag1.earthActive1 == true || EarthSeedDrag2.earthActive2 == true || EarthSeedDrag3.earthActive3 == true){
                seedHeight = 1;
            }
            if (FireSeedDrag.fireActive == true || FireSeedDrag1.fireActive1 == true || FireSeedDrag2.fireActive2 == true || FireSeedDrag3.fireActive3 == true){
                seedHeight = 2;
            }
            if (WaterSeedDrag.waterActive == true || WaterSeedDrag1.waterActive1 == true || WaterSeedDrag2.waterActive2 == true || WaterSeedDrag3.waterActive3 == true){
                seedHeight = 3;
            }
            if (WindSeedDrag.windActive == true || WindSeedDrag1.windActive1 == true || WindSeedDrag2.windActive2 == true || WindSeedDrag3.windActive3 == true){
                seedHeight = 4;
            }

    }
}
