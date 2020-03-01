using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int energy;
    public int startEnergy = 5;

    private int lives;
    public int startLives = 5;

    private bool isAlive = true;

    void Start()
    {
        energy = startEnergy;
        lives = startLives;
    }

    public void TakeDamage(int damage)
    {
        if (isAlive)
        {
            lives -= damage;
            FindObjectOfType<StatsUI>().UpdateHealthCounter();
            CheckLives();
        }
    }

    public void SpendEnergy(int cost) => energy -= cost;

    void CheckLives()
    {
        if (lives <= 0)
        {
            isAlive = false;
            FindObjectOfType<GameManager>().LostGame();
        }
    }

    public int GetLives() => lives;

    public int GetEnergy() => energy;
}