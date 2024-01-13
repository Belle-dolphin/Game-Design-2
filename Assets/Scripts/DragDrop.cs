using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler  
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public GameObject objectToDrag;
    public GameObject objectDragToPos;

    public bool isLocked;

    public BlocksCounting blockCounting;

    Vector2 objectinitialPos;

    void Start()
    {
        // Gets the start position of the object to drag
        objectinitialPos = objectToDrag.transform.position;
    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData) {}

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Changes the opacity of the object to drag and allows it to be dragged
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Changes the opacity of the object to drag and allows it to be dragged
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
         // Define the position of the window frame
        Vector2 windowPos = new Vector2(-102, 29.63919f);

        // Define the size of the window frame
        Vector2 windowSize = new Vector2(990, 489);

        // Define the boundaries of the window frame
        Vector2 minBounds = windowPos - windowSize / 1.6f;
        Vector2 maxBounds = windowPos + windowSize / 1.6f;

        // If the object is not locked, it can be dragged
        if (!isLocked)
        {
            Vector2 newPos = rectTransform.anchoredPosition + eventData.delta / canvas.scaleFactor;

            // Clamp the new position within the boundaries
            newPos.x = Mathf.Clamp(newPos.x, minBounds.x, maxBounds.x);
            newPos.y = Mathf.Clamp(newPos.y, minBounds.y, maxBounds.y);

            rectTransform.anchoredPosition = newPos;
        }
    }

    public void OnDrop(PointerEventData eventData) {}

    public void DropObject() 
    {
        // Gets the distance between the object to drag and the object to drag to
        float distance = Vector3.Distance(objectToDrag.transform.position, objectDragToPos.transform.position);
        if (distance < 120) 
        {
            isLocked = true;
            objectToDrag.transform.position = objectDragToPos.transform.position; // Sets the object to drag to the object to drag to
            blockCounting.SetBlockNum();
        } 
        else
        {
            objectToDrag.transform.position = objectinitialPos; // Sets the object to drag to the initial position of the object to drag
        }
    }
}
