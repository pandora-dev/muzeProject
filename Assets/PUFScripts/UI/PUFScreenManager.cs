using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUFScreenManager : MonoBehaviour
{
    public bool findViewsAutomatically;
    public List<PUFView> views;
    public int currentScreenIndex;
    private SwipeDetector sDetector;

    public event Action<SwipeData> OnScreenSwiped = delegate { };

    void Start()
    {
        if (this.GetComponent<Canvas>() == null)
        {
            Debug.LogError("This script must be attached into Canvas");
        }
        else if (this.GetComponent<SwipeDetector>() == null)
        {
            Debug.LogError("There should be a swipe detector in Mobile apps!");
        }
        else
        {
            InitialiseScreenManagement();
            
        }

    }
    
    public void Next()
    {
        views[currentScreenIndex].Transition(PUFView.TransitionType.CenterToLeftOut,2.0f);
        currentScreenIndex++;
        views[currentScreenIndex].Transition(PUFView.TransitionType.RightToCenterIn, 2.0f);

    }
    public void Prev()
    {
        views[currentScreenIndex].Transition(PUFView.TransitionType.CenterToRightOut, 2.0f);
        currentScreenIndex--;
        views[currentScreenIndex].Transition(PUFView.TransitionType.LeftToCenterIn, 2.0f);

    }
    public void ScreenSwiped(SwipeData s)
    {
        OnScreenSwiped(s);
    }

    void InitialiseScreenManagement()
    {

        currentScreenIndex = 0;
        int i = 0;
        if(findViewsAutomatically)
        {
            views = new List<PUFView>();
            foreach(Transform t in PUFHierarchyHelper.ChildTransforms(this.transform))
            {
                if(t.GetComponent<PUFView>()!=null)
                {
                    views.Add(t.GetComponent<PUFView>());
                }
            }
        }

        //attach swipe event into ScreenManagement
        sDetector = this.GetComponent<SwipeDetector>();
        sDetector.OnSwipe += ScreenSwiped;


    }
    
}
