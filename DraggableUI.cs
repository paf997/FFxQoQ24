using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DraggableUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Transform Transform;
    private CanvasGroup canvasGroup;
    private Mask tokenMask;

    [SerializeField] RectTransform playArea;
    private void Awake()
    {
        Transform = GetComponent<Transform>();
        canvasGroup = GetComponent<CanvasGroup>();
        tokenMask = GetComponentInParent<Mask>();  // Assuming the Mask is on the parent of the image
        //int playAreaX1 = playArea.position.x;
        //int playAreaX2 = playArea.rect;
        //Debug.Log("X2 ->>>" + playAreaX2);
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

         Debug.Log(" Event data  " + eventData);
    }
    public void OnDrag(PointerEventData eventData)
    {
        Transform.position = eventData.position;  // Move the token with the drag
        //Debug.Log(" x: " + Transform.position.x);
        //Debug.Log(" y: " + Transform.position.y);
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

        if (Transform.position.x < 220 && Transform.position.x > 30 && Transform.position.y > -10 && Transform.position.y < 150 ){
            Debug.Log("play Area");
        } else if (Transform.position.x < 460 && Transform.position.x > 272 && Transform.position.y > -10 && Transform.position.y < 150 ){
            Debug.Log("discard Area");
        } else{
            Debug.Log("Not play or discard Area");
        }   
    }

    /*private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Thee has entered - collision");
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Thee has entered - Trigger ");
    }*/
}



