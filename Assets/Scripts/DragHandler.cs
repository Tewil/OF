using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{
    
	public static GameObject itemBeingDragged;
	Vector3 startPosition;
	Transform startParent;
	
	#region IBeginDragHandler implementation
	
	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;
		GetComponent<CanvasGroup>().blocksRaycasts = false;
		transform.SetParent(transform.root);
	}
	
	#endregion
	
	#region IDragHandler implementation
	
	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}
	
	#endregion
	
	#region IEndDragHandler implementation
	public void OnEndDrag (PointerEventData eventData)
	{
		itemBeingDragged = null;
     if (transform.parent == startParent || transform.parent == transform.root)
     {
         transform.position = startPosition;
         transform.SetParent(startParent);
     }
     GetComponent<CanvasGroup>().blocksRaycasts = true;
	}
	
	#endregion
	
	
}
