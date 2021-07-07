using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNGGenerate : MonoBehaviour
{
	public Texture png;
	
	public Image myImageComponent;
	public Image x;
	
	public Sprite mySprite;
	
	void Start()
    {
        GameObject thePlayer = GameObject.Find("ThePlayer");
        PNGListCreator PNGScript = thePlayer.GetComponent<PNGListCreator>();
		png = PNGScript.pngs[5];
        
    }
	
    public void generatePNG() 
	{
		//could not be the right component; can be the button i grabbed there
		myImageComponent = this.GetComponent<Image>();
		//TODO:
		//Print png to myImageComponent = Source Image of Image in panel
		//myImageComponent.sprite = png;
		
		
	}
}
