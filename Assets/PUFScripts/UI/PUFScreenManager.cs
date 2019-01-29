using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUFScreenManager : MonoBehaviour
{
    public bool findViewsAutomatically;
    public List<PUFView> views;

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
    void InitialiseScreenManagement()
    {

        //get views into list<views> && activate first one
        int i = 0;
        if(findViewsAutomatically)
        {
            views = new List<PUFView>();
            foreach(Transform t in PUFHierarchyHelper.ChildTransforms(this.transform))
            {
                if(t.GetComponent<PUFView>()!=null)
                {
                    if(i==0){
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
