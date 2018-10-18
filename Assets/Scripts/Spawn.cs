using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

public GameObject playerGroup;
public float dropREverySeconds = 2f;

	// Use this for initialization
	void Start () {

	InvokeRepeating("DropPlayers", 10f,10f);
		
	}
	
	// Update is called once per frame
	void Update () {

	//if(Time.realtimeSinceStartup%dropREverySeconds == 0){


	}

	void DropPlayers(){
		Instantiate(playerGroup);

	
	}
				
	
}
