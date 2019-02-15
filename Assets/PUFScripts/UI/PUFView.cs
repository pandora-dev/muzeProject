using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUFView : MonoBehaviour
{

    private bool transitionStarted;
    private float transitionCountDown;
    private TransitionType currentTransitionType;
    private bool isActive;

    public void Activate()
    {
        isActive = true;
        this.transform.gameObject.SetActive(true);
    }
    public void Deactivate()
    {
        isActive = false;
        this.transform.gameObject.SetActive(false);
    }
    public void Transition(TransitionType t,float transitionSpeed)
    {
        currentTransitionType = t;
        transitionCountDown = transitionSpeed;
        if (t==TransitionType.CenterToLeftOut)
        {
            this.GetComponent<Animator>().SetTrigger("isCenterToLeftOut");
            transitionStarted = true;
        }
        else if(t==TransitionType.RightToCenterIn)
        {
            this.Activate();
            this.GetComponent<Animator>().SetTrigger("isRightToCenterIn");
            transitionStarted = true;

        }
        else if (t == TransitionType.LeftToCenterIn)
        {
            this.Activate();
            this.GetComponent<Animator>().SetTrigger("isLeftToCenterIn");
            transitionStarted = true;

        }
        else if (t == TransitionType.CenterToRightOut)
        {
            
            this.GetComponent<Animator>().SetTrigger("isCenterToRightOut");
            transitionStarted = true;

        }
    }

    public enum TransitionType { CenterToLeftOut,RightToCenterIn,LeftToCenterIn,CenterToRightOut}
  
}
