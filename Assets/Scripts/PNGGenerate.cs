using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PNGGenerate : MonoBehaviour
{
	public Image myImageComponent;
	public Sprite[] pngs;
	public GameObject[] flowers;
	public static GameObject objectSpawn;
	
	
	void Start()
    {
		myImageComponent = this.GetComponent<Canvas>().GetComponent<Image>();
    }
	
    public void generatePNG() 
	{
        if (GlobalCount.count == 3) {
            myImageComponent.overrideSprite = pngs[29];
            objectSpawn = flowers[29];
        }
        else {
            myImageComponent.overrideSprite = null;
            objectSpawn = null;
        }

	}
}
