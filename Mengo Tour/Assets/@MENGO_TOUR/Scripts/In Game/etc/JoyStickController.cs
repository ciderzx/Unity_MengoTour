using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private RectTransform rect_Background;
    [SerializeField] private RectTransform rect_Joystick;

    private float radius;

    // [SerializeField] private GameObject go_Player;
    [SerializeField] private float moveSpeed;

    private bool isTouched = false;
    private Vector3 movePosition;

    // Start is called before the first frame update
    void Start()
    {
        radius = rect_Background.rect.width * 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        // if (isTouched)
        //     go_Player.transform.position += movePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 value = eventData.position - (Vector2)rect_Background.position;
        value = Vector2.ClampMagnitude(value, radius);
        // float dragX = Mathf.Clamp(value.x, -rectWidth, rectWidth);
        // float dragY = Mathf.Clamp(value.y, -rectHeight, rectHeight);
        rect_Joystick.localPosition = value;

        value = value.normalized; // 방향만 남음
        // movePosition = new Vector3(value.x * moveSpeed * Time.deltaTime, 0f, value.x * moveSpeed * Time.deltaTime);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouched = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouched = false;
        rect_Joystick.localPosition = Vector3.zero;
    }

}
