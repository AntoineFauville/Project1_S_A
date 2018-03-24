using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {

	public int health;
	public float distance;
	float distanceMin = 1.5f;

	void Start () {
		health = 5;
		StartCoroutine (WaitHealthCalculation());
	}
	

	void Update () {

		if(distance > distanceMin){
			transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(4,0));
		}

		distance = Vector3.Distance (transform.position, GameObject.Find ("Wall").transform.position);
		//print (distance);

		if (health <= 0) {
			GameObject.DestroyImmediate (this.gameObject);
		}
	}

	IEnumerator WaitHealthCalculation(){
		yield return new WaitForSeconds (0.5f);
		if (distance <= distanceMin) {
			health -= 1;
			transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100,200));
		}
		StartCoroutine (WaitHealthCalculation());
	}
}
