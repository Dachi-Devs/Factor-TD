using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    public Text energyCounter;
    public Text healthCounter;

    void Start()
    {
        UpdateEnergyCounter();
        UpdateHealthCounter();
    }

    public void UpdateEnergyCounter()
    {
        energyCounter.text = "Energy: " + PlayerStats.energy;
    }

    public void UpdateHealthCounter()
    {
        healthCounter.text = "Health: " + PlayerStats.lives;
    }
}
