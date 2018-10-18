using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

[SerializeField] int playerLives = 3;
	[SerializeField] int score = 0;
	[SerializeField] float timeDead = 2f;
	[SerializeField] Text livesTxt;
	[SerializeField] Text scoreTxt;

private void Awake(){

//this is how you make a singleton

int numGameManagers = FindObjectsOfType<GameManager>().Length;
if (numGameManagers>1){Destroy(gameObject);}else{DontDestroyOnLoad(gameObject);}
}

	// Use this for initialization
	void Start () {

	livesTxt.text = playerLives.ToString();
	scoreTxt.text = score.ToString();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void AddToScore(int pointsToAdd){

	score+=pointsToAdd;
	scoreTxt.text = score.ToString();	

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
	livesTxt.text = playerLives.ToString();
	var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
	SceneManager.LoadScene(currentSceneIndex);

	}
}
