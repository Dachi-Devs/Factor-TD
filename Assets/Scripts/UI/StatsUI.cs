using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    public Text energyCounter;
    public Text healthCounter;
    private PlayerStats ps;

    void Start()
    {
        ps = FindObjectOfType<PlayerStats>();
        UpdateEnergyCounter();
        UpdateHealthCounter();
    }

    public void UpdateEnergyCounter() => energyCounter.text = "Energy: " + ps.GetEnergy();

    public void UpdateHealthCounter() => healthCounter.text = "Health: " + ps.GetLives();
}
