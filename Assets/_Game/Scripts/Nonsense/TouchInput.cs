using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public static event Action OnClicked;

    public Vector2 TouchScreenPosition { get; private set; }
    public bool TouchIsHeld { get; private set; }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            //Debug.Log("TouchIsHeld = true");

            TouchIsHeld = true;
            // update touch location
            Touch touch = Input.GetTouch(0);

            //update location
            TouchScreenPosition = touch.position;

            // detect if this touch just happened
            if (touch.phase == TouchPhase.Began)
            {
                OnClicked?.Invoke();
            }
            
        }
        else
        {
            //Debug.Log("TouchIsHeld = false");
            TouchIsHeld = false;
        }
    }
}
