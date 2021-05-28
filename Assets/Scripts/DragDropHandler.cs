using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    /// <summary>
    /// Item that is currently dragged
    /// </summary>
    private static GameObject _itemBeingDragged;

    public static GameObject GetItemBeingDragged() => _itemBeingDragged;

    /// <summary>
    /// Element covering the entire UI canvas
    /// </summary>
    private Transform _globalDragParent;

    /// <summary>
    /// Canvas group used to enable and disable interactions
    /// </summary>
    private CanvasGroup _canvasGroup;
    
    /// <summary>
    /// Initial drag position.
    /// </summary>
    private Vector3 _startPosition;

    /// <summary>
    /// The grid
    /// </summary>
    private Transform _startParent;

    private void Start()
    {
        _globalDragParent = GameObject.FindGameObjectWithTag("GlobalDragParent").transform;
    }

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _itemBeingDragged = gameObject;
        _startPosition = transform.position;
        _startParent = transform.parent;

        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 0.8f;
        
        transform.SetParent(_globalDragParent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _itemBeingDragged = null;
        transform.position = _startPosition;

        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.alpha = 1f;
        
        transform.SetParent(_startParent);
    }
}
