using UnityEngine;
using UnityEngine.EventSystems;

public class BuildManager : MonoBehaviour
{
    public GameObject turretPrefab;
    public Transform turretMaster;
    public GameObject buildUI;
    private TurretController turret;
    private PlayerStats ps;
    public Color selectedColour;
    public LayerMask turretLayer;

    void Start()
    {
        ps = FindObjectOfType<PlayerStats>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { CheckForTurretSpot(); }
    }

    public void BuildOnSite(Transform siteToBuild)
    {
        if (ps.GetEnergy() > 0)
        {
            ps.SpendEnergy(1);
            FindObjectOfType<StatsUI>().UpdateEnergyCounter();
            Instantiate(turretPrefab, siteToBuild.position, Quaternion.identity, turretMaster);
        }
    }

    void SetTurret(TurretController _turret)
    {
        turret = _turret;
        turret.GetComponent<SpriteRenderer>().color = selectedColour;
        ToggleBuildUI(true);
    }

    void ClearTurret()
    {
        if (turret != null)
        {
            turret.GetComponent<SpriteRenderer>().color = Color.white;
            turret = null;
            ToggleBuildUI(false);
        }
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

    void ToggleBuildUI(bool setToState)
    {
        buildUI.SetActive(setToState);
    }

    void CheckForTurretSpot()
    {
        Ray rayDirection = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(rayDirection, out hit, 15.0f, turretLayer))
        {
            SetTurret(hit.transform.GetComponent<TurretController>());
        }
        else if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        else
        {
            ClearTurret();
        }
    }
}
