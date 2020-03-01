using UnityEngine;
using UnityEngine.UI;

public class TurretController : MonoBehaviour
{
    [SerializeField]
    private Enemy targetEnemy;
    private BuildManager bm;
    public float range;
    public float fireRate;
    public float fireCountdown;

    public enum TargetFindingMode
    {
        First,
        Last,
        Closest,
        Largest,
    }
    [SerializeField]
    private TargetFindingMode targetMode;
    public int value = 1;
    private Text valueText;
    private string enemyTag = "Enemy";
    // Start is called before the first frame update
    void Start()
    {
        valueText = GetComponentInChildren<Text>();
        bm = FindObjectOfType<BuildManager>();
        UpdateValueText();
        InvokeRepeating("CheckForEnemies", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Countdown();
    }

    void Countdown()
    {
        if (fireCountdown > 0) { fireCountdown -= Time.deltaTime; }

        if (targetEnemy == null)
        {
            return;
        }

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = fireRate;
        }
    }

    void CheckForEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float distanceToTarget = 0;
        switch (targetMode)
        {
            case TargetFindingMode.First:
                {
                    int firstEnemyIndex = 0;
                    GameObject firstEnemy = null;

                    foreach (GameObject enemy in enemies)
                    {
                        int valueOfEnemy = enemy.GetComponent<Enemy>().value;
                        if (valueOfEnemy % value == 0)
                        {
                            int enemyIndex = enemy.GetComponent<EnemyMovement>().ReturnWaypointIndex();
                            if (enemyIndex > firstEnemyIndex)
                            {
                                firstEnemyIndex = enemyIndex;
                                firstEnemy = enemy;
                                distanceToTarget = Vector3.Distance(transform.position, enemy.transform.position);
                            }
                        }
                    }

                    if (firstEnemy != null && distanceToTarget <= range)
                    {
                        targetEnemy = firstEnemy.GetComponent<Enemy>();
                    }
                    break;
                }
            case TargetFindingMode.Last:
                {
                    int lastEnemyIndex = 10000;
                    GameObject lastEnemy = null;

                    foreach (GameObject enemy in enemies)
                    {
                        int valueOfEnemy = enemy.GetComponent<Enemy>().value;
                        if (valueOfEnemy % value == 0)
                        {
                            int enemyIndex = enemy.GetComponent<EnemyMovement>().ReturnWaypointIndex();
                            if (enemyIndex < lastEnemyIndex)
                            {
                                lastEnemyIndex = enemyIndex;
                                lastEnemy = enemy;
                                distanceToTarget = Vector3.Distance(transform.position, enemy.transform.position);
                            }
                        }
                    }

                    if (lastEnemy != null && distanceToTarget <= range)
                    {
                        targetEnemy = lastEnemy.GetComponent<Enemy>();
                    }
                    break;
                }
            case TargetFindingMode.Closest:
                {
                    float shortestDistance = Mathf.Infinity;
                    GameObject closestEnemy = null;

                    foreach (GameObject enemy in enemies)
                    {
                        int valueOfEnemy = enemy.GetComponent<Enemy>().value;
                        if (valueOfEnemy % value == 0)
                        {
                            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                            if (distanceToEnemy < shortestDistance)
                            {
                                shortestDistance = distanceToEnemy;
                                closestEnemy = enemy;
                            }
                        }
                    }

                    if (closestEnemy != null && shortestDistance <= range)
                    {
                        targetEnemy = closestEnemy.GetComponent<Enemy>();
                    }
                    else
                    {
                        targetEnemy = null;
                    }
                    break;
                }
            case TargetFindingMode.Largest:
                {
                    int largestValue = 0;
                    GameObject largestEnemy = null;

                    foreach (GameObject enemy in enemies)
                    {
                        int valueOfEnemy = enemy.GetComponent<Enemy>().value;
                        if (valueOfEnemy % value == 0)
                        {
                            if (valueOfEnemy > largestValue)
                            {
                                largestValue = valueOfEnemy;
                                largestEnemy = enemy;
                                distanceToTarget = Vector3.Distance(transform.position, enemy.transform.position);
                            }
                        }
                    }

                    if (largestEnemy != null && distanceToTarget <= range)
                    {
                        targetEnemy = largestEnemy.GetComponent<Enemy>();
                    }
                    break;
                }
        }
    }

    void Shoot()
    {
        targetEnemy.GetComponent<Enemy>().Damage(value);
    }

    void UpdateValueText()
    {
        valueText.text = value.ToString();
    }

    public void IncreaseTurretLevel()
    {
        value++;
        UpdateValueText();
    }
}