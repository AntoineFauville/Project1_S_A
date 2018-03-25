using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	void Start  () {
		transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(700,0));
		StartCoroutine (DieEventually ());
	}

	void Update () {
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "wall") {

			GameObject.Find ("Wall").GetComponent<BossController> ().looseHealth (1);

			GameObject.Destroy (this.gameObject);
		}
	}

	IEnumerator DieEventually(){
		yield return new WaitForSeconds (2.0f);
		GameObject.Destroy (this.gameObject);
	}
}