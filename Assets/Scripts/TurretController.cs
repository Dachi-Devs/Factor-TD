using UnityEngine;
using UnityEngine.UI;

public class TurretController : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;
    private BuildManager bm;
    public float range;
    public float fireRate;
    public float fireCountdown;

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

        if (target == null)
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
        float shortestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<Enemy>().value % value == 0)
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
            target = closestEnemy.transform;
            targetEnemy = closestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
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

    void OnMouseDown()
    {
        bm.SetTurret(this);
        bm.ToggleBuildUI(true);
    }
}