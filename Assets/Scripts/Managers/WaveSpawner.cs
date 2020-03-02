using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int waveNumber = 0;
    public int waveValue;
    public float spawnGrace;
    public PlayerStats ps;

    void Start()
    {
        ps = FindObjectOfType<PlayerStats>();
    }

    public void EnableSpawns()
    {
        StartCoroutine(SpawnNewWave());
    }

    IEnumerator SpawnNewWave()
    {
        int waveCount = 5;
        waveCount +=  (2 * waveNumber);
        waveCount = Random.Range(waveCount - 3, waveCount + 3);

        for (int i = 0; i < waveCount; i++)
        {
            int enemyValue;
            if (waveNumber < 5) { enemyValue = Random.Range(1, 3); }
            else { enemyValue = Random.Range((waveNumber / 2 + 2), waveNumber + 2); }
            SpawnEnemy(enemyValue);
            spawnGrace = Random.Range(0.6f, 1.4f);
            waveValue += enemyValue;
            yield return new WaitForSeconds(spawnGrace);
        }

        ps.SpendEnergy(-(waveValue / 2));
        waveNumber++;
    }

    void SpawnEnemy(int value)
    {
        GameObject e = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        e.GetComponent<Enemy>().SetupEnemy(value);
    }
}
