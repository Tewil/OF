using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNGGenerate : MonoBehaviour
{
	public Sprite png;
	public Image myImageComponent;
	public Sprite[] pngs;
	public GameObject[] flowers;
	
	
	
	void Start()
    {
		myImageComponent = this.GetComponent<Canvas>().GetComponent<Image>();
    }
	
    public void generatePNG() 
	{
		myImageComponent.overrideSprite = pngs[2];
	}
}
