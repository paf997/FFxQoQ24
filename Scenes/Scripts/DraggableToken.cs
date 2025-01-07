using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableToken : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Mask tokenMask;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        tokenMask = GetComponentInParent<Mask>();  // Assuming the Mask is on the parent of the image
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0.6f;  // Optional: make token semi-transparent while dragging
            canvasGroup.blocksRaycasts = false;  // Allow dragging through other UI elements
        }

        // Disable the mask while dragging
        if (tokenMask != null)
        {
            tokenMask.enabled = false;  // Disable mask so the image is not clipped during drag
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = eventData.position;  // Move the token with the drag
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 1f;  // Restore the original transparency
            canvasGroup.blocksRaycasts = true;  // Enable raycasts again
        }

        // Re-enable the mask after dragging
        if (tokenMask != null)
        {
            tokenMask.enabled = true;  // Re-enable mask to apply the masking effect again
        }
    }
}


