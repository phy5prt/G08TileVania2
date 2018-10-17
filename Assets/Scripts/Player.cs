﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

//config
[SerializeField] float runSpeed =5f;
	[SerializeField] float climbSpeed =5f;
	[SerializeField] float jumpSpeed = 5f;
//State
bool isAlive = true;


Rigidbody2D myRigidBody;
Animator myAnimator;
Collider2D myColl;
	// Use this for initialization

	//messages then methods
	void Start () {

	myRigidBody = GetComponent<Rigidbody2D>();
	myAnimator = GetComponent<Animator>();
	myColl = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {

	ClimbLadder();
	Run();	
	Jump();	


		
	}

	private void Run(){


	float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // value between -1 to +1
	Vector2 playerVelocity = new Vector2(controlThrow*runSpeed, myRigidBody.velocity.y );
	myRigidBody.velocity = playerVelocity;
print (playerVelocity);


	bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x)>Mathf.Epsilon; //would have to change so based on current values if in game character will be changing size
	myAnimator.SetBool("Running",playerHasHorizontalSpeed);	
	if(playerHasHorizontalSpeed){transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x),1);}
		
		
	

	}

	private void Jump(){
		if(!myColl.IsTouchingLayers(LayerMask.GetMask("Ground")) && !myColl.IsTouchingLayers(LayerMask.GetMask("Ladder"))){return;}
		//also want it to only jump if horizontal speed if on a ladder and to jump off the ladder not just reattach
	if(CrossPlatformInputManager.GetButtonDown("Jump")){
	Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
	myRigidBody.velocity += jumpVelocityToAdd;
	}

	}

	private void ClimbLadder(){

		if(!myColl.IsTouchingLayers(LayerMask.GetMask("Ladder"))){
			myAnimator.SetBool("Climb",false);
			myRigidBody.gravityScale = 1;	
		return;}
		myRigidBody.gravityScale = 0;
		float controlThrow = CrossPlatformInputManager.GetAxis("Vertical"); // value between -1 to +1
		Vector2 playerVelocity = new Vector2(myRigidBody.velocity.x, controlThrow*climbSpeed);
		//myRigidBody.velocity = playerVelocity; //ive added a plus may go too fast //or maybe only alter the speed if up being pressed 
		if(controlThrow != 0){myRigidBody.velocity = playerVelocity;} //if add += for less than zero will slide down ladders faster and faster and will add you x too so with level design
		//could get made exploit
		bool playerHasVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y)>Mathf.Epsilon; //would have to change so based on current values if in game character will be changing size
	
		myAnimator.SetBool("Climb",playerHasVerticalSpeed);	


		


	}
	}
