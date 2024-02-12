using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [HideInInspector]
    public bool pressed;
    [HideInInspector]
    // public bool pressedCrouching;

    public void OnPointerDown(PointerEventData eventData)
    {
        // if (gameObject.name == "Crouch Button")
        // pressedCrouching = true;
        // if (gameObject.name == "Jump Button")
        pressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        // if (gameObject.name == "Crouch Button")
        // pressedCrouching = false;
        // if (gameObject.name == "Jump Button")
        pressed = false;
    }

}
