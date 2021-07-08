using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNGGenerate : MonoBehaviour
{
	public Sprite png;
	
	public Image myImageComponent;
	
	public GameObject example;
	
	
	
	void Start()
    {
		
        GameObject thePlayer = GameObject.Find("ThePlayer");
        PNGListCreator PNGScript = thePlayer.GetComponent<PNGListCreator>();
		png = PNGScript.pngs[5];
		myImageComponent = this.GetComponent<Canvas>().GetComponent<Image>();
		
		
    }
	
    public void generatePNG() 
	{
		
		
		
		myImageComponent.overrideSprite = png;
		
		
	}
}
