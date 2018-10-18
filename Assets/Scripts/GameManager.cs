using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

[SerializeField] int playerLives = 3;
	[SerializeField] float timeDead = 2f;

private void Awake(){

//this is how you make a singleton

int numGameManagers = FindObjectsOfType<GameManager>().Length;
if (numGameManagers>1){Destroy(gameObject);}else{DontDestroyOnLoad(gameObject);}
}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void ProccessPlayerDeath(){

	StartCoroutine(PlayerDeath());


	}
	IEnumerator PlayerDeath(){

	yield return new WaitForSecondsRealtime(timeDead);
		if(playerLives>1){TakeLife();}
	else{ResetGameSession();} // will this also reset lives?


	}


	private void ResetGameSession(){
SceneManager.LoadScene(0);
	Destroy(gameObject);
	} 

	private void TakeLife(){
	//shouldnt we reset the transform
	playerLives --;
	var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
	SceneManager.LoadScene(currentSceneIndex);

	}
}
