using UnityEngine;

public class BuildUI : MonoBehaviour
{
    private BuildManager bm;
    // Start is called before the first frame update
    void Start()
    {
        bm = FindObjectOfType<BuildManager>();
    }

    public void UpgradeButton()
    {
        bm.UpgradeTurret();
    }
}
