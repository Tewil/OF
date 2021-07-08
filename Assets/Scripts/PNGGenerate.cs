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
	//public GameObject example;

	
	
	void Start()
    {
		myImageComponent = this.GetComponent<Canvas>().GetComponent<Image>();
        //objectSpawn = this.GetComponent<ObjectSpawner>();
		//example.SetActive(false);
    }
	
    public void generatePNG() 
	{
		myImageComponent.overrideSprite = pngs[29];
        objectSpawn = flowers[29];
        //this.GetComponent<ObjectSpawner>().objectToSpawn = flowers[9];
        //objectSpawn.objectToSpawn = flowers[9];
		//example.SetActive(true);
	}
}
