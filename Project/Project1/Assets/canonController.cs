using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canonController : MonoBehaviour {

	public GameObject spawnPoint;
	public GameObject prefabCanon;

    public float spawnTime = 1f;

	void Start () {
		StartCoroutine (WaitUpdate ());
	}

	IEnumerator WaitUpdate (){
		yield return new WaitForSeconds (spawnTime);

		GameObject pref;
		pref = prefabCanon;

		Instantiate (pref, spawnPoint.transform);

		StartCoroutine (WaitUpdate ());
	}
}
