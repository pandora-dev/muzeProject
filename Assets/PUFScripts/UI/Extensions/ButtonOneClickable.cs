using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonOneClickable : Button
{
    public float delayTime;
    private float remainingTime;
    private bool waitStarted;

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (!waitStarted)
        {
            
            base.OnPointerClick(eventData);
            waitStarted = true;
            remainingTime = delayTime;
        }
            
        
    }
    public void Update()
    {
        if(waitStarted)
        {
            remainingTime -= Time.deltaTime;
            if(remainingTime<0)
            {
                waitStarted = false;
            }
        }
    }
}
