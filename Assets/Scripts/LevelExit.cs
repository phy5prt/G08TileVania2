using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {

[SerializeField] float LevelLoadDelay = 2f;
[SerializeField] float LevelExitSloMoFactor = 0.2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D player){

	if(player.tag != "Player"){return;}

	StartCoroutine(LoadNextLevel());



	}

	IEnumerator  LoadNextLevel(){

	Time.timeScale = LevelExitSloMoFactor;
	yield return new WaitForSecondsRealtime(LevelLoadDelay);
	Time.timeScale=1f;

	var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
	SceneManager.LoadScene(currentSceneIndex+1);

	}

}
