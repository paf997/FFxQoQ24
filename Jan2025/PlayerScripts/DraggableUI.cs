using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableUI2 : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Transform draggableTransform;
    private Vector3 originalPosition;

    private void Awake()
    {
        draggableTransform = GetComponent<Transform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = draggableTransform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(eventData.position);
        worldPoint.z = draggableTransform.position.z; // Maintain the z-axis position
        draggableTransform.position = worldPoint;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DetectCollision();
    }

    private void DetectCollision()
    {
        Collider2D thisCollider = GetComponent<Collider2D>();
        if (thisCollider == null)
        {
            Debug.LogWarning("No Collider2D attached to the draggable object.");
            return;
        }

        // Check for collisions with other GameObjects with colliders
        Collider2D[] overlappingColliders = Physics2D.OverlapBoxAll(thisCollider.bounds.center, thisCollider.bounds.size, 0);
        foreach (var collider in overlappingColliders)
        {
            if (collider.gameObject != gameObject)
            {
                Debug.Log($"{gameObject.name} is touching {collider.gameObject.name}");
                // Handle collision logic
            }
        }
    }
}

