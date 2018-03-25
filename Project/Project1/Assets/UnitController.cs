using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitController : MonoBehaviour {

	public int health = 1;
	public int attack = 1;

	float distance;
	float selfDamageRange = 1.5f;

	public float attackSpeed = 0.5f;
	public float attackRange = 1f;

	public Text unitText;
	string textIndicator; //range indicator

	void Start () {
		health = 5;
		StartCoroutine (WaitHealthCalculation());
		StartCoroutine (WaitRangeCalculation());

		UpdateText ();
	}
	

	void Update () {

		UpdateText ();

		if(distance > selfDamageRange){
			transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(4,0));
		}

		distance = Vector3.Distance (transform.position, GameObject.Find ("WallDetection").transform.position);
		//print (distance);

		if (health <= 0) {
			GameObject.DestroyImmediate (this.gameObject);
		}
	}

	void UpdateText()
	{
		unitText.text = health.ToString () + " " + textIndicator;

		if (distance <= attackRange) {
			textIndicator = "I'm in Range !";
		} else {
			textIndicator = "";
		}
	}

	IEnumerator WaitHealthCalculation(){
		yield return new WaitForSeconds (0.7f);
		if (distance <= selfDamageRange) {
			health -= 1;
			transform.GetComponent<Rigidbody2D> ().gravityScale = 0;
			transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(-250,250));
			yield return new WaitForSeconds (0.2f);
			transform.GetComponent<Rigidbody2D> ().gravityScale = 1;
		}

		StartCoroutine (WaitHealthCalculation());
	}

	IEnumerator WaitRangeCalculation(){
		yield return new WaitForSeconds (attackSpeed);
		if (distance <= attackRange) {
			GameObject.Find ("Wall").GetComponent<BossController> ().looseHealth (attack);
		}

		StartCoroutine (WaitRangeCalculation());
	}
}
