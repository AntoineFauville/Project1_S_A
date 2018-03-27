using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

    public int energyNecessary;
    
	void Update () {
	    if(energyNecessary <= GameObject.Find("ScriptManager").GetComponent<EnergyController>().Energy)
        {
            this.gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }
	}
}
