using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PNGGenerate : MonoBehaviour
{
	public static Image myImageComponent;
	public Sprite[] pngs;
	public GameObject[] flowers;
	public static GameObject objectSpawn;
	
	
	void Start()
    {
		myImageComponent = this.GetComponent<Canvas>().GetComponent<Image>();
    }
	
    public void generatePNG() 
	{
            myImageComponent.overrideSprite = pngs[29];
            objectSpawn = flowers[29];
	}
}
