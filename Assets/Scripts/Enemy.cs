using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public int value = 0;
    public Text valueText;
    public Image healthBar;

    public int healthCurrent;

    public int bounty;

    public GameObject deathEffect;
    private PlayerStats ps;




    // Start is called before the first frame update
    void Start()
    {
        ps = FindObjectOfType<PlayerStats>();
        healthCurrent = value;
        UpdateValueText();
        UpdateHealthBar();
        bounty = value / 2;
    }

    void UpdateValueText()
    {
        valueText.text = value.ToString();
    }

    void UpdateHealthBar()
    {
        float healthPercent = healthCurrent;
        healthPercent /= value;
        healthBar.fillAmount = healthPercent;
    }

    public void Damage(int x)
    {
        healthCurrent -= x;
        UpdateHealthBar();
        CheckForHealth();
    }

    void CheckForHealth()
    {
        if (healthCurrent <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        ps.SpendEnergy(-bounty);
        FindObjectOfType<StatsUI>().UpdateEnergyCounter();
        //GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 3f);
        Destroy(gameObject);
    }
}
