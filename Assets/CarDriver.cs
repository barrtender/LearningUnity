﻿using UnityEngine;
using System.Collections;

public class CarDriver : MonoBehaviour {
	public float forwardSpeed = 5.0f;
	public float backwardSpeed = 2.0f;
	public float turnRate = 80.9f;
	
	public Transform lowestGroundObject;
	public Transform respawnPosition;
	
	public GUIText debugOutput;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		KeepStraight();
		
		if(Input.GetKey(KeyCode.Escape)){
			Application.Quit();
		}
		
		if(transform.position.y < 0 ){//lowestGroundObject.position.y) {
			//Respawn();
			transform.position.Set(transform.position.x, 0, transform.position.z);
		}
		debugOutput.text = "point: x=" + transform.position.x + ", y=" + transform.position.y + ", z=" + transform.position.z;
		
		if(Input.GetKey(KeyCode.W)) {
			transform.position += transform.forward * forwardSpeed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.S)) {
			transform.position += transform.forward * -backwardSpeed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.A)) {
			transform.Rotate(0.0f, -turnRate * Time.deltaTime, 0.0f);
		}
		if(Input.GetKey(KeyCode.D)) {
			transform.Rotate(0.0f, turnRate * Time.deltaTime, 0.0f);
		}
		if(Input.GetKeyDown(KeyCode.X)) {
			transform.position += Vector3.up;
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
			transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
		}
	}
	
	public void KeepStraight() {
		transform.position.Set(transform.position.x, 0, transform.position.z);
		transform.rotation.Set(0,transform.rotation.y, 0, 0);// = respawnPosition.rotation;
		rigidbody.angularVelocity = Vector3.zero;
	}
	
	public void Respawn() {
		transform.position = respawnPosition.position;
		rigidbody.velocity = Vector3.zero;
		transform.rotation = respawnPosition.rotation;
		rigidbody.angularVelocity = Vector3.zero;
	}
	/*void FixedUpdate() {
		if(Input.GetKey(KeyCode.W)) {
			rigidbody.AddForce(transform.forward * 20);
		}
	}*/
}
