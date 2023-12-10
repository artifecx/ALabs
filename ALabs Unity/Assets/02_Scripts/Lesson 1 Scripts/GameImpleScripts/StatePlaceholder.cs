using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StatePlaceholder : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData)
    {
        /* Debug.Log("ON Drop");
         if(eventData.pointerDrag != null)
         {
             eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
             Debug.Log("object dropped on: " + name);
             _placeholder = FindObjectOfType<GameObject>().name.Contains();
         }*/

        Debug.Log("OnDrop");

        /*if (eventData.pointerDrag != null)
        {
            RectTransform draggedRectTransform = eventData.pointerDrag.GetComponent<RectTransform>();
            RectTransform targetRectTransform = GetComponent<RectTransform>();

            // Set the anchored position of the dragged object to the target's anchored position
            draggedRectTransform.anchoredPosition = targetRectTransform.anchoredPosition;

            Debug.Log("Object dropped on: " + name);
        }*/

        if (eventData.pointerDrag != null)
        {
            RectTransform draggedRectTransform = eventData.pointerDrag.GetComponent<RectTransform>();
            RectTransform targetRectTransform = GetComponent<RectTransform>();

            // Set the anchored position of the dragged object to the target's anchored position
            draggedRectTransform.anchoredPosition = targetRectTransform.anchoredPosition;

            Debug.Log("Object dropped on: " + eventData.delta);

            // Find the GameObject by name
            GameObject placeholder1 = GameObject.Find(name);

            // Do something with the found GameObject
            if (placeholder1 != null)
            {
                Debug.Log("Found Placeholder1: " + placeholder1.name);
                // You can access components or perform other operations on placeholder1 here
            }
            else
            {
                Debug.LogWarning("Placeholder1 not found");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
