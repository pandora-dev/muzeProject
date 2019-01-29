using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUFScreenManager : MonoBehaviour
{
    public bool findViewsAutomatically;
    public List<PUFView> views;
    private int currentScreenIndex;

    void Start()
    {
        if (this.GetComponent<Canvas>() == null)
        {
            Debug.LogError("This script must be attached into Canvas");
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
                    if(i==0||i==1||i==2){
                        t.GetComponent<PUFView>().Activate();
                    }
                    else { t.GetComponent<PUFView>().Deactivate();
                    }
                    views.Add(t.GetComponent<PUFView>());
                    i++;
                }
            }
        }
        
    }
    
}
