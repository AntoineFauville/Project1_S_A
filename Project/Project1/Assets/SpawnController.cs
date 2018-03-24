using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

	public GameObject[] Unit;
	public GameObject[] SpawnPoints;

	public void OnClic(int unitIndex){
		Instantiate (Unit[unitIndex],SpawnPoints[unitIndex].transform);
	}
}
