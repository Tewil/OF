using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PNGGenerate : MonoBehaviour
{
	public Sprite png;
	public Image myImageComponent;
	public Sprite[] pngs;
	public GameObject[] flowers;
    public GameObject objectToSpawn;

	
	
	void Start()
    {
		myImageComponent = this.GetComponent<Canvas>().GetComponent<Image>();
    }
	
    public void generatePNG() 
	{
		myImageComponent.overrideSprite = pngs[2];
        SceneManager.LoadScene("PlantScene", LoadSceneMode.Single);/////at this line
        objectToSpawn = GameObject.Find("ObjectSpawner");
        objectToSpawn = flowers[9];
	}
}
