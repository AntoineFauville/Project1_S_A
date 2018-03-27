using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyController : MonoBehaviour {

    public Text energyText;

    public int maxEnergy = 10;
    public int Energy;
    
    public GameObject[] buttons;
	
	void Start () {
        Energy = maxEnergy;
        UpdateText();

    }

    void UpdateText() {
        energyText.text = Energy + " / " + maxEnergy;
    }

    private void Update()
    {
        if (Energy <= 0)
        {
            Energy = 0;
        }
            
        if (Energy > maxEnergy)
            Energy = maxEnergy;

        UpdateText();
    }

    public void UseEnergy(int energyV)
    {
        Energy -= energyV;
    }

    public void GetBackEnergy(int energyV)
    {
        Energy += energyV;
    }
}
