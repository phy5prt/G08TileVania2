
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour {

	private int scenePersisting;     // -1 because I want to be able to search for ScenePersist (s) that have not yet been assigned a sceneBuildindex number to them
										// which happens in start

 void Awake(){


		scenePersisting = SceneManager.GetActiveScene().buildIndex;

		ScenePersist[] scenePersists = FindObjectsOfType<ScenePersist>();   //array of all ScenePersist (s)
			foreach(ScenePersist scenePersist in scenePersists){
				if(scenePersist.scenePersisting !=   SceneManager.GetActiveScene().buildIndex) //destroy gameObjects that dont have this sceneBuild
						{
							Debug.Log(" destroying in foreach ");
							Destroy(scenePersist.gameObject);}}

		Debug.Log(" scenePersist value " + scenePersisting + " I think this level build is (during the wake) " + SceneManager.GetActiveScene().buildIndex);


	//having destroyed the gameObjects I dont want there should only be left the one made with this scene, and ones from previous loads of THIS scene 

		int numScenePersists = FindObjectsOfType<ScenePersist>().Length;  
		Debug.Log("number scenePersist = " + numScenePersists);

	//if there is more than 1 ScenePersist then because this scenePersist is running the Awake method it must be the new one and should be destroyed
		if (numScenePersists>1){Debug.Log("destroying in if >1");  Destroy(gameObject);}                              
		//else{DontDestroyOnLoad(gameObject);}												


//there should only be one ScenePersist that isnt destroyed by the time it reaches this point in the code which will be the first time a scenePersist is made for a particular scene
//it therefore should not be destroyed on load																																																				
		DontDestroyOnLoad(gameObject);																				


		
 
}



	void Start () {



		
	}
	
	void Update () {

		
	}


}
