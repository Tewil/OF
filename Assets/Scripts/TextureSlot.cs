using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextureSlot : MonoBehaviour, IDropHandler
{
    public static bool itsOnDropTexture;
    public static int seedTexture;

    void Start(){
        itsOnDropTexture = false;
        seedTexture = 0;
    }

    public void OnDrop(PointerEventData eventData) {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            itsOnDropTexture = true;
            if (EarthSeedDrag.earthActive == true || EarthSeedDrag1.earthActive1 == true || EarthSeedDrag2.earthActive2 == true || EarthSeedDrag3.earthActive3 == true){
                seedTexture = 1;
            }
            if (FireSeedDrag.fireActive == true || FireSeedDrag1.fireActive1 == true || FireSeedDrag2.fireActive2 == true || FireSeedDrag3.fireActive3 == true){
                seedTexture = 2;
            }
            if (WaterSeedDrag.waterActive == true || WaterSeedDrag1.waterActive1 == true || WaterSeedDrag2.waterActive2 == true || WaterSeedDrag3.waterActive3 == true){
                seedTexture = 3;
            }
            if (WindSeedDrag.windActive == true || WindSeedDrag1.windActive1 == true || WindSeedDrag2.windActive2 == true || WindSeedDrag3.windActive3 == true){
                seedTexture = 4;
            }

    }
}
