using UnityEngine;

public class GridObject : MonoBehaviour
{
    private bool isOccupied;
    private BuildManager bm;
    // Start is called before the first frame update
    void Start()
    {
        bm = FindObjectOfType<BuildManager>();
    }

    void OnMouseDown()
    {
        if (!isOccupied)
        {
            bm.ToggleBuildUI(false);
            bm.BuildOnSite(transform);
            isOccupied = true;
        }
    }
}
