using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class dragDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Camera cam;
    [SerializeField] private towerSpawner towerSpawner;
    [SerializeField] private GameObject parent;
    [SerializeField] private float dragScale;
    [SerializeField] private float towerVerticalOffset;
    private GameObject draggedObject;
    private GameObject hitSlab;
    private GameObject hitButton;
    private string draggedType;
    private Vector3 pos;

    GameObject getRayCastHit(Vector2 pos)
    {
        Ray ray = cam.ScreenPointToRay(pos);
        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            return hit.transform.gameObject;
        }
        return parent; // N'est jamais censé arriver
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        // Permet de reconnaitre quel bouton a été pressé et de faire appaitre l'image sur le curseur
        hitButton = eventData.pointerPressRaycast.gameObject;
        draggedObject = Instantiate(hitButton, parent.transform);
        draggedObject.transform.position = hitButton.transform.position;
        draggedObject.transform.localScale = new Vector3(dragScale, dragScale, dragScale);
        draggedType = draggedObject.GetComponent<Image>().name;
        draggedType = draggedType.Split('-')[1].Trim();
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        draggedObject.transform.position += new Vector3(eventData.delta.x, eventData.delta.y, 0);
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        // Détruit l'image de prévisualisation et fait apparaitre une tourelle
        Destroy(draggedObject);
        hitSlab = getRayCastHit(eventData.position);
        if(hitSlab.name != "DirtSlab(Clone)")
        {
            pos = hitSlab.transform.position;
            pos.y += towerVerticalOffset;
            towerSpawner.spawn(draggedType, pos, hitSlab.transform.parent);
        }
    }
}
