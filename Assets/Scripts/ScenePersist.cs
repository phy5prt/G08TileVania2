
//if(collision is CapsuleCollider2D)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour {

//maybe post up an error again lecture 331

//int startingSceneIndex;
	private int scenePersisting = -1; // used in my code
	// Use this for initialization
 void Awake(){

 //ive added these lines based on my top code however i feel still may not work as dont know in what order they awake - but hopefully should only be one awaking!
		ScenePersist[] scenePersists = FindObjectsOfType<ScenePersist>();
		foreach(ScenePersist scenePersist in scenePersists){
		if((scenePersist.scenePersisting != -1) && (scenePersist.scenePersisting !=   SceneManager.GetActiveScene().buildIndex)){Debug.Log("destroying in foreach");Destroy(scenePersist.gameObject);}}

		//if it is not running code in order maybe just need to count how many and delete them later and delete this.gameObject if i dont need it.
		//hmm it count 2 when there is one is this because does not call in order
		int numScenePersists = FindObjectsOfType<ScenePersist>().Length; //eh if it is running the above it must be the last left so why destroy itself
		Debug.Log(numScenePersists);
		if (numScenePersists>1){Debug.Log("destroying in if >1");  Destroy(gameObject);}                                  //how does it know which is the most up to date one // because the persisted one awoke when it was first made
		//else{DontDestroyOnLoad(gameObject);}												//it isnt remade it simply persists - but there code doesnt work because when increase level you are destroying
																				//in update so only after you have destroyed the new one that you wanted to keep
		DontDestroyOnLoad(gameObject);																				//need to die and reload that scene and now it will work


		
 /*//my attempt not sure why it didnt completely work -but may work better than theres
//this is how you make a singleton
	//does not work if sending you to the first level becuase it is from there
		//if made array of existing and looped through and checked if any had the current level persist name and if they dont then do not delete the -1 one. 

		int numScenePersists = FindObjectsOfType<ScenePersist>().Length;
		if (numScenePersists>1){                                                     //if more than the first time level loaded perist
			if (scenePersisting != -1 ||scenePersisting !=   SceneManager.GetActiveScene().buildIndex){Destroy(gameObject);}   //if it isnt the persist that came with this level //not work because if running awake then first time created
				numScenePersists = FindObjectsOfType<ScenePersist>().Length;
					if(numScenePersists>1){if(scenePersisting == -1){Destroy(gameObject);} } }                                     //if still more than one persist we want to delete the one just mad

					//we have destroyed all but one the last one altered
					//this code assumes awake is recalled on reload and that the int wont be reinitialized

DontDestroyOnLoad(gameObject);

	
	//think the other did work but just not on first level maybe need if lives are full and it is the first level destroy anything not minus one
	//previous was better!
	//	int numScenePersists = FindObjectsOfType<ScenePersist>().Length;
	//	if (numScenePersists>1){  if(scenePersisting !=   SceneManager.GetActiveScene().buildIndex){Destroy(gameObject);}}
	//	DontDestroyOnLoad(gameObject);
	*/
}



	void Start () {

scenePersisting = SceneManager.GetActiveScene().buildIndex; //used in my code for peristing game objects
		//startingSceneIndex= SceneManager.GetActiveScene().buildIndex;
		
	}
	
	// Update is called once per frame
	void Update () {

	//int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
	//if(currentSceneIndex!= startingSceneIndex){Destroy(gameObject);} // so it must not run awake or start if it persists
		
	}



}
