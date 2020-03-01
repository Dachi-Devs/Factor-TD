using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject turretPrefab;
    public GameObject buildUI;
    public Vector2 buildUIOffset;
    public TurretController turret;

    public void BuildOnSite(Transform siteToBuild)
    {
        if (PlayerStats.energy > 0)
        {
            PlayerStats.energy--;
            FindObjectOfType<StatsUI>().UpdateEnergyCounter();
            Instantiate(turretPrefab, siteToBuild.position, Quaternion.identity, siteToBuild);
        }
    }

    public void SetTurret(TurretController _turret)
    {
        turret = _turret;
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.energy > 0)
        {
            PlayerStats.energy--;
            FindObjectOfType<StatsUI>().UpdateEnergyCounter();
            turret.IncreaseTurretLevel();
        }
    }

    public void ToggleBuildUI(bool setToState)
    {
        buildUI.SetActive(setToState);
    }
}
