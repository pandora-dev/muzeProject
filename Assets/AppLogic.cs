using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class AppLogic : MonoBehaviour
{

    private PUFScreenManager pScreenManager;
    public int tutorialHorizontalScrollStepCount;
    public HorizontalScrollSnap tutorialHorizontalScrollSnap;
    public PaginationManager tutorialPaginationManager;

    


    public void Start()
    {

        pScreenManager = this.GetComponent<PUFScreenManager>();
        pScreenManager.OnScreenSwiped += ScreenSwiped;

        
    }

    public void ScreenSwiped(SwipeData s)
    {
        if(s.Direction==SwipeDirection.Left)
        {
            if(tutorialPageLatestSwipe())
            {
                pScreenManager.Next();
            }
            else
            {
                if(isTutorialPage())
                {
                    tutorialPaginationManager.GoToScreen(tutorialPaginationManager.CurrentPage + 1);
                }
                
            }
            
        }
        else if(s.Direction==SwipeDirection.Right)
        {
            if(isTutorialPage())
            {
                tutorialPaginationManager.GoToScreen(tutorialPaginationManager.CurrentPage + -1);
            }
            
            
        }
    }

    private bool tutorialPageLatestSwipe()
    {
        return (isTutorialPage() && tutorialHorizontalScrollSnap.CurrentPage == tutorialHorizontalScrollStepCount - 1);
    }
    private bool isTutorialPage()
    {
        if(pScreenManager.currentScreenIndex==0)
        {
            return true;
        }
        else
        {
           return false;
        }
    }
}
