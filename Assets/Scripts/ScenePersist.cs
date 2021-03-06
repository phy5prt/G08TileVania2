
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour {

	//no longer assigning -1 as i believe we know this is the new scenePersist because it is running awake
	//and dont destroy on load doesnt cause a gameObject to rerun awake and start methods (i think)


	//still unsure if this needs to be [serialized] what effect would have if public, and if I could still access it if I deleted it here and
	//put i solely in the Awake() does that work because same class can find any variable in another of same class?!
	private int scenePersisting;     

										

 void Awake(){

 //code works but still fails if you die on first level after losing all lives, in this instance the oldscene persist is not replaced by the new one
 //a solution would be either changing the scene perist's scenePerisisting int in the revert to level one to restart game method
 //or simply destroying it in that instance.

 		int numSPWithThisSceneBuildNum = 0;
		scenePersisting = SceneManager.GetActiveScene().buildIndex;


		//array of all ScenePersist (s) and counting the ones with the scene build number
		//this works whereas counting the remaining ones after destroying the ones we did not want
		//did not work because it seemed to count the ones that had been destroyed in previous lines of code
		//i think this is due to execution order but i dont really understand it and I am not sure.

		//this works instead by counting the ones that match the build order we want as one instruction
		//deleting the gameObjects as a seperate instruction so it does not matter if they are not destroyed in an order
		//matching the code.


		ScenePersist[] scenePersists = FindObjectsOfType<ScenePersist>();   
			foreach(ScenePersist scenePersist in scenePersists){
				if(scenePersist.scenePersisting ==  SceneManager.GetActiveScene().buildIndex) {numSPWithThisSceneBuildNum++;}else	{Destroy(scenePersist.gameObject);} }  

		
		//because we are no longer destroying the gameObjects in the awake we are having to do it in the update,
		//i had wanted to avoid this if possible


	//if there is more than 1 ScenePersist assign with this scenes build ord 
	//then because this scenePersist is running the Awake method it must be the new one and should be destroyed
	//However if the player has died losing all their lives in the first scene it should be the old one that dies
		if (numSPWithThisSceneBuildNum>1){Debug.Log("destroying in if >1");  Destroy(gameObject);}                              
												


																																																		
		DontDestroyOnLoad(gameObject);																				


		
 
}



	void Start () {



		
	}
	
	void Update () {

	
		
	}


}
