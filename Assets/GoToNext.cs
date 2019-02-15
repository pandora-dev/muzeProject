using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class GoToNext : MonoBehaviour
{

    private int prevIndex;
    public int currentIndex;
    public PUFScreenManager pScreenManager;
    private HorizontalScrollSnap currHorizontalScrollSnap;
    
    // Start is called before the first frame update
    void Start()
    {
        currHorizontalScrollSnap = this.GetComponent<HorizontalScrollSnap>();

        if(!currHorizontalScrollSnap)
        {
            Debug.LogError("Horizontal Scroll Snap couldn't find!");
        }
        else
        {
            
            currentIndex = currHorizontalScrollSnap.StartingScreen;
            prevIndex = currentIndex;
        }
    }

    public void CurrentIndex()
    {
        try
        {
            prevIndex = currHorizontalScrollSnap.CurrentPage;
        }
        catch
        {
            prevIndex = 0;
        }
        
    }
    public void NextIndex()
    {
        currentIndex = currHorizontalScrollSnap.CurrentPage;
        CheckTransition();
    }

    private void CheckTransition()
    {
        if (currentIndex == prevIndex && currentIndex == 2)
        {
            pScreenManager.Next();
        }
    }


}
