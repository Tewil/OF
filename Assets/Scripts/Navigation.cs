using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class Navigation : MonoBehaviour
{
    public GameObject home_panel;
	public GameObject craft_panel;
	public GameObject plant_panel;
	
	
	void Start()
    {
		
        home_panel.SetActive(true);
		craft_panel.SetActive(false);
		plant_panel.SetActive(false);
        
    }
	public void homePage() 
	{
		home_panel.SetActive(true);
		craft_panel.SetActive(false);
		plant_panel.SetActive(false);
		
	}
	
	public void craftPage() 
	{
		home_panel.SetActive(false);
		craft_panel.SetActive(true);
		plant_panel.SetActive(false);
		
	}
	
	public void plantPage() 
	{
		home_panel.SetActive(false);
		craft_panel.SetActive(false);
		plant_panel.SetActive(true);
		LoaderUtility.Initialize();
		SceneManager.LoadSceneAsync("PlantScene", LoadSceneMode.Single);
		
	}
}
