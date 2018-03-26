using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public int damage;
    public int addForce;

	void Start  () {
		transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(addForce, 0));
		StartCoroutine (DieEventually ());
	}

	void Update () {
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "wall") {

			GameObject.Find ("ScriptManager").GetComponent<BossController> ().looseHealth (damage);

			GameObject.Destroy (this.gameObject);
		}

        if (col.gameObject.tag == "unit")
        {
            col.gameObject.GetComponent<UnitController>().UnitLooseHealth(1);

            GameObject.Destroy(this.gameObject);
        }
    }

	IEnumerator DieEventually(){
		yield return new WaitForSeconds (5.0f);
		GameObject.Destroy (this.gameObject);
	}
}