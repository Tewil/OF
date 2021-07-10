using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public void resetCraftPanel() {
		//hier objekte zurück setzen
		
		SceneManager.LoadScene("MainScene"); 
		

	}
}
