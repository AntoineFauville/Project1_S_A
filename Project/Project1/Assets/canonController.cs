using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canonController : MonoBehaviour {

	public GameObject spawnPoint;
	public GameObject prefabCanon;

	void Start () {
		StartCoroutine (WaitUpdate ());
	}

	IEnumerator WaitUpdate (){
		yield return new WaitForSeconds (1f);

		GameObject pref;
		pref = prefabCanon;

		Instantiate (pref, spawnPoint.transform);

		StartCoroutine (WaitUpdate ());
	}
}
