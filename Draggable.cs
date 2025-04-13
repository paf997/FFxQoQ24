using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    // Initial position of the token when dragging starts
    private Vector3 initialPosition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Called when the drag starts
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Store the initial position of the token
        initialPosition = rectTransform.position;

        // Optionally make the object semi-transparent while dragging
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false; // Allows raycasting to pass through while dragging
        }
    }

    // Called during the drag (when the object is being moved)
    public void OnDrag(PointerEventData eventData)
    {
        // Move the object with the mouse position
        rectTransform.position = eventData.position;
    }

    // Called when the drag ends
    public void OnEndDrag(PointerEventData eventData)
    {
        // Optionally reset the transparency back to normal
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true; // Enable raycasting again
        }

        // Optionally return to the initial position if dropped in an invalid area
        // rectTransform.position = initialPosition;
    }

    public void OnMouseClick(PointerEventData eventData){
        
    }
}
