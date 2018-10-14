using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour {


	public float speed;
	public float rotspeed;
	Rigidbody rb;
	public bool isGrounded;
	public float jumpHeight;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		isGrounded = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.CompareTag("Jumping"))
		{
			rb.AddForce(0, jumpHeight * 2, 0);
		}
	}
}
