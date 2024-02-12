using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyPanelHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private RectTransform look_Background;
    private Transform cameraTransform;

    private float radius = 10f;

    private float rectWidth;
    private float rectHeight;

    private bool isTouched = false;
    private float rotationSpeed = 10f;

    private Vector2 previousPosition;
    private Vector2 nextPosition;

    [HideInInspector]
    public Vector2 LookValue;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 value = eventData.position - previousPosition;
        // Vector2 value = previousPosition - (Vector2)look_Background.position;
        LookValue = Vector2.ClampMagnitude(value, radius).normalized;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        previousPosition = eventData.position;
        isTouched = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouched = false;
        previousPosition = Vector2.zero;
        LookValue = Vector2.zero;
    }
}
