using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinPickup : MonoBehaviour {

[SerializeField] public AudioClip coinPickUpSFX;
[SerializeField] int myValue = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private void OnTriggerEnter2D(Collider2D player){

	Debug.Log("cointouched");
	if(player.tag != "Player"){return;}
		AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position ); //this worked too GameObject.Find("Main Camera").gameObject.transform.position
	GameObject.FindObjectOfType<GameManager>().AddToScore(myValue);
	Destroy(gameObject);}

}
