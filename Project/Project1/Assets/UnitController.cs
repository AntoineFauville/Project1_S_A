using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitController : MonoBehaviour {

	public int health = 1;
	public int attack = 1;

	float distance;
	float selfDamageRange = 1.1f;

	public float attackSpeed = 0.5f;
	public float attackRange = 1f;

    public int energyValue = 1;

	public Text unitText;
	string textIndicator; //range indicator

    bool a,b;

	void Start () {
		StartCoroutine (WaitHealthCalculation());
		StartCoroutine (WaitRangeCalculation());
        //StartCoroutine(WaitLazer());

        UpdateText ();
	}
	

	void Update () {

		UpdateText ();

		

		distance = Vector3.Distance (transform.position, GameObject.Find ("WallDetection").transform.position);
        //print (distance);

       if (health <= 0 && !a) {

            a = true;

            GameObject.Find("ScriptManager").GetComponent<EnergyController>().GetBackEnergy(energyValue);
            
            gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(150,150,150,0.5f);
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;

            StartCoroutine(Waitdie());
        }
        else
        {
            if (distance > selfDamageRange)
            {
                transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(4, 0));
            }
        }
	}

    public void UnitLooseHealth(int healthAmount)
    {
        health -= healthAmount;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "powa") {
            UnitLooseHealth(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "powa2" && !b)
        {
            b = true;
            StartCoroutine(WaitLazer());
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

    IEnumerator Waitdie() {
        yield return new WaitForSeconds(4f);
        GameObject.DestroyImmediate(this.gameObject);
    }

    IEnumerator WaitLazer()
    {
        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(0.5f);
            UnitLooseHealth(1);
        }
        b = false;
    }

    IEnumerator WaitHealthCalculation(){
		yield return new WaitForSeconds (0.7f);
		if (distance <= selfDamageRange) {
            UnitLooseHealth(1);
			transform.GetComponent<Rigidbody2D> ().gravityScale = 0;
			transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100,0));
			yield return new WaitForSeconds (0.2f);
			transform.GetComponent<Rigidbody2D> ().gravityScale = 1;
		}

		StartCoroutine (WaitHealthCalculation());
	}

	IEnumerator WaitRangeCalculation(){
		yield return new WaitForSeconds (attackSpeed);
		if (distance <= attackRange) {
			GameObject.Find ("ScriptManager").GetComponent<BossController> ().looseHealth (attack);
		}

		StartCoroutine (WaitRangeCalculation());
	}
}
