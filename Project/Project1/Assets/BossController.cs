using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour {

	public Text levelText;
	public Text HealthText;

	int bossLevel;
	int bossHealth;

	public int initialBossLevel;
	public int initialBossHealth;

	// Use this for initialization
	void Start () {
		bossLevel = initialBossLevel;
		bossHealth = initialBossHealth;

		UpdateText ();

        StartCoroutine(PowerAttackLazer());
    }

	void UpdateText (){
		levelText.text = bossLevel.ToString();
		HealthText.text = bossHealth.ToString() + " / " + initialBossHealth.ToString();
	}

	public void looseHealth(int health){
		bossHealth -= health;
	}

	void Update () {
	
		UpdateText ();

		if (bossHealth <= 0) {
			bossLevel++;
			bossHealth = initialBossHealth;
			//StartCoroutine(PowerAttack ());
		}
	}

	IEnumerator PowerAttack () {
		for (int i = 0; i < 6; i++) {
			yield return new WaitForSeconds (0.005f);
			GameObject.Find ("Powa").transform.localScale += new Vector3(10,10,0);
		}
		yield return new WaitForSeconds (0.06f);
		GameObject.Find ("Powa").transform.localScale = new Vector3(1,1,1);
	}

    IEnumerator PowerAttackLazer()
    {
        GameObject.Find("Powa2").GetComponent<BoxCollider2D>().enabled = false;
        GameObject.Find("Powa2").GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(3f);

        GameObject.Find("Powa2").GetComponent<BoxCollider2D>().enabled = true;
        GameObject.Find("Powa2").GetComponent<SpriteRenderer>().enabled = true;

        yield return new WaitForSeconds(1f);

        StartCoroutine(PowerAttackLazer());
    }
}
