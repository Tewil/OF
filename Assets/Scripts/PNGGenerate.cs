using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNGGenerate : MonoBehaviour
{
	public Texture png;
	
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
		
		Sprite NewSprite = Sprite.Create((Texture2D)png,
		new Rect(0, 0, 100, 100), 
		new Vector2(0, 0), 1, 0);
		
		example.SetActive(true);
		//hanging up down here
		myImageComponent.sprite = NewSprite;
		
		
	}
}
