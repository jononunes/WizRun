using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private bool swipeUp, swipeDown, tap;
    private bool isDragging = false;
    private Vector2 startTouch, swipeDelta;

    private void Update()
    {
        tap = swipeUp = swipeDown = false;



        #region Mobile Inputs
        if(Input.touches.Length > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;
                swipeUp = true;
            }
            else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDragging = false;
                Reset();
            }
        }
        #endregion   

        //Calculate distance
        swipeDelta = Vector2.zero;
        if(isDragging)
        {
             if(Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;

            }
            
        }


        //Did we cross the deadzone?
        if(swipeDelta.magnitude >= 1)
        {
            //Which direction 
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if(Mathf.Abs(x) < Mathf.Abs(y))
            {
                if(y < 0)
                {
                    swipeDown = true;
                }
                else
                {
                    swipeUp = true;
                }
            }
            
            Reset();
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;

    }

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
}
