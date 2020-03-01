using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject turretPrefab;
    public GameObject buildUI;
    private TurretController turret;
    private PlayerStats ps;

    void Start()
    {
        ps = FindObjectOfType<PlayerStats>();
    }

    public void BuildOnSite(Transform siteToBuild)
    {
        if (ps.GetEnergy() > 0)
        {
            ps.SpendEnergy(1);
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
        if (ps.GetEnergy() > 0)
        {
            ps.SpendEnergy(1);
            FindObjectOfType<StatsUI>().UpdateEnergyCounter();
            turret.IncreaseTurretLevel();
        }
    }

    public void ToggleBuildUI(bool setToState)
    {
        buildUI.SetActive(setToState);
    }
}
