using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WaterSeedDrag3 : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    Vector3 startPosition;
	Transform startParent;
    public bool dragAble;
    public static bool waterActive3;

    void Start() {
        startPosition = transform.position;
        startParent = transform.parent;
        dragAble = true;
        waterActive3 = false;
    }

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }


    public void OnBeginDrag(PointerEventData eventData) {
        if (dragAble == false) {
            this.enabled = false;
        } else {
        waterActive3 = true;
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData) {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData) {
        canvasGroup.alpha = 1f;
        if (HeightSlot.itsOnDropHeight == true || ColorSlot.itsOnDropColor == true || TextureSlot.itsOnDropTexture == true) {
            dragAble = false;
            HeightSlot.itsOnDropHeight = false;
            ColorSlot.itsOnDropColor = false;
            TextureSlot.itsOnDropTexture = false;
        }
        else {
            transform.position = startPosition;
            transform.SetParent(startParent);
            waterActive3 = false;
            canvasGroup.blocksRaycasts = true;
        }

    }

    public void OnPointerDown(PointerEventData eventData) {

    }
}
