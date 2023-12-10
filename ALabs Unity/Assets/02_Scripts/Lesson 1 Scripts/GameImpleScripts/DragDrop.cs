using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler 
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    [SerializeField] private Canvas canvas;
    private Vector2 originalPosition;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = rectTransform.anchoredPosition;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Pointer drag began: " + name);
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Pointer currently dragging: " + name);
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Pointer Drag end: " + name);
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        if (eventData.pointerCurrentRaycast.gameObject == null || !eventData.pointerCurrentRaycast.gameObject.CompareTag("Placeholders"))
        {
            rectTransform.anchoredPosition = originalPosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer Clicked Down: " + name);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
