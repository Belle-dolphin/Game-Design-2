using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public void OnBeginDrag(PointerEventData eventData)
    {
        GameObject[] containers = GameObject.FindGameObjectsWithTag("FullContainer");
        Canvas canvas = FindObjectOfType<Canvas>();
        
        // Loop over all full container and find the parent of the item
        foreach (GameObject container in containers)
        {
            if (this.transform.IsChildOf(container.transform))
            {
                this.transform.SetParent(canvas.transform);
                container.tag = "EmptyContainer";
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = transform.position.z - Camera.main.transform.position.z;
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject[] containers = GameObject.FindGameObjectsWithTag("EmptyContainer");
        GameObject closestContainer = null;
        float distance = Mathf.Infinity;

        // Loop over all the empty containers and find the closest container
        foreach (GameObject container in containers)
        {
            if (Vector3.Distance(transform.position, container.transform.position) < distance)
            {
                distance = Vector3.Distance(transform.position, container.transform.position);
                closestContainer = container;
            }
        }

        // If the container is "close enough", we attach the item to the container
        if (distance < 1)
        {
            transform.position = closestContainer.transform.position;
            this.transform.SetParent(closestContainer.transform);
            closestContainer.tag = "FullContainer";
        }
    }

}
