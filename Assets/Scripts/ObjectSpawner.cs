using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
	private PlacementIndicator placementIndicator;
	
	void Start ()
	{
		placementIndicator = FindObjectOfType<PlacementIndicator>();
        objectToSpawn = PNGGenerate.objectSpawn;
			
	}
	
	void Update () 
	{
		if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
		{
			GameObject obj = Instantiate(objectToSpawn, placementIndicator.transform.position,
									placementIndicator.transform.rotation);
			DontDestroyOnLoad(obj);
			
		}
		if (Input.GetKeyDown(KeyCode.Escape)) {
            
            // Quit the application
            LoaderUtility.Initialize();
			SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Single);
        }
		
	}
	
}
