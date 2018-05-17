using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pigeon : MonoBehaviour {
	// states ->  0 - idle, 1 - takeoff, 2 - flying
	private int state = 0;
	private float idleTime = 10.0f;
	private float flyingTime = 100.0f;
	private int direction = 1;

	private float speed = 1.0f;


	Rigidbody2D p_Rigidbody;


	Animator animator; 
	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();
		p_Rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (flyingTime);
		Debug.Log (state);
		if (state == 0) {
			idleTime-=0.1f;
			if (idleTime <= 0) {
				state = 1;
			}
		}
		if (state == 1) {
			animator.SetBool("pigeon-takeoff", true);
			state = 2;
			idleTime = 10.0f;
		}
		if (state == 2) {
			flyingTime -= 0.1f;

			if (gameObject.transform.position.y < 3) {

				p_Rigidbody.velocity = new Vector3(p_Rigidbody.velocity.x, speed, 0f);
			} else {
				gameObject.transform.position = new Vector3 (gameObject.transform.position.x, 3.0f, 0.0f);
			}

			p_Rigidbody.velocity = new Vector3(speed * 1.4f * -direction, p_Rigidbody.velocity.y, 0f);



			if (flyingTime == 0) {
				state = 0;
				flyingTime = 100.0f;
			}
		}
		
	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "wall"){
			direction = direction * (-1);
			transform.eulerAngles += new Vector3 (0f, 180.0f,   0f); 
		}
	}
}
