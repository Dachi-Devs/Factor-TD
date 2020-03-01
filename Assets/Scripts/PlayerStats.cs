using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int energy;
    public int startEnergy = 5;

    public static int lives;
    public int startLives = 5;

    void Start()
    {
        energy = startEnergy;
        lives = startLives;
    }
}