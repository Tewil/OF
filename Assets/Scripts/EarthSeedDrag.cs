using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EarthSeedDrag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    Vector3 startPosition;
	Transform startParent;

    void Start() {
        startPosition = transform.position;
        startParent = transform.parent;
    }

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }


    public void OnBeginDrag(PointerEventData eventData) {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        HeightSlot.itsOnDrop = false;
        ColorSlot.itsOnDrop = false;
        TextureSlot.itsOnDrop = false;
    }

    public void OnDrag(PointerEventData eventData) {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData) {
        canvasGroup.alpha = 1f;
        if (HeightSlot.itsOnDrop == true || ColorSlot.itsOnDrop == true || TextureSlot.itsOnDrop == true) {

        }
        else {
            transform.position = startPosition;
            transform.SetParent(startParent);
            if (GlobalCount.count <= 0) {
                }
            else {
                GlobalCount.count--;
            }
        }
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData) {

    }
}
