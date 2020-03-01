using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    public Text energyCounter;

    public void UpdateEnergyCounter()
    {
        energyCounter.text = "Energy: " + PlayerStats.energy;
    }
}
