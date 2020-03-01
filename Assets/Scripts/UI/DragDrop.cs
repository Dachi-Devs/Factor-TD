using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IDragHandler, IEndDragHandler, IDropHandler
{
    private Camera cam;
    [SerializeField]
    private LayerMask gridLayer;

    void Start()
    {
        cam = Camera.main;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnDrop(PointerEventData eventData)
    {
        CheckBelowItem();
    }

    void CheckBelowItem()
    {
        Ray rayDirection = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(rayDirection.origin, rayDirection.direction * 15.0f, Color.red, 3f);
        if (Physics.Raycast(rayDirection, out hit, 15.0f, gridLayer))
        {
            FindObjectOfType<BuildManager>().BuildOnSite(hit.transform);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
    }
}
