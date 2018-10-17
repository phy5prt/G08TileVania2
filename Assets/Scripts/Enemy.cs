using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


[SerializeField] float moveSpeed = 1f;
Rigidbody2D myRigidBody;
public float maxXPos;
public float minXPos;
private Collider2D myEnemyColl;

	// Use this for initialization
	void Start () {
		myRigidBody  = GetComponent<Rigidbody2D>();
		myRigidBody.velocity = Vector2.right*moveSpeed;
		myEnemyColl = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {

		//
	//	Debug.Log(myEnemyColl.IsTouchingLayers(LayerMask.GetMask("Ground")));
			if(myEnemyColl.IsTouchingLayers(LayerMask.GetMask("Ground"))){myRigidBody.velocity = myRigidBody.velocity*-1;}

	if(transform.position.x > maxXPos){	myRigidBody.velocity = Vector2.left*moveSpeed;}
		else if (transform.position.x <= minXPos)  {	myRigidBody.velocity = Vector2.right*moveSpeed;}

transform.localScale = new Vector2 (Mathf.Sign(myRigidBody.velocity.x),transform.localScale.y);
	}
}
