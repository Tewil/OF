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
	public ObjectSpawner objectSpawner;
	public GameObject example;

	
	
	void Start()
    {
		myImageComponent = this.GetComponent<Canvas>().GetComponent<Image>();
		example.SetActive(false);
    }
	
    public void generatePNG() 
	{
		
		myImageComponent.overrideSprite = pngs[15];
		example.SetActive(true);
        //objectSpawner.objectToSpawn = flowers[9];
	}
}
