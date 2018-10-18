using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinPickup : MonoBehaviour {

[SerializeField] public AudioClip coinPickUpSFX;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private void OnTriggerEnter2D(Collider2D player){

	Debug.Log("cointouched");
	if(player.tag != "Player"){return;}
	AudioSource.PlayClipAtPoint(coinPickUpSFX, GameObject.Find("Main Camera").gameObject.transform.localPosition);

	Destroy(gameObject);}

}
