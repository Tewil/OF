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
	//public ObjectSpawner objectSpawn;
	//public GameObject example;

	
	
	void Start()
    {
		myImageComponent = this.GetComponent<Canvas>().GetComponent<Image>();
        //objectSpawn = this.GetComponent<ObjectSpawner>();
		//example.SetActive(false);
    }
	
    public void generatePNG() 
	{
		
		myImageComponent.overrideSprite = pngs[15];
        this.GetComponent<ObjectSpawner>().objectToSpawn = flowers[9];
        //ObjectSpawner.objectToSpawn = flowers[9];
		//example.SetActive(true);
	}
}
