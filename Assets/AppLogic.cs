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

    private bool isFirstSkipTry;


    public void Start()
    {

        pScreenManager = this.GetComponent<PUFScreenManager>();
        pScreenManager.OnScreenSwiped += ScreenSwiped;

        isFirstSkipTry = true;
    }

    public void ScreenSwiped(SwipeData s)
    {
        if(s.Direction==SwipeDirection.Left)
        {
            if(tutorialPageLatestSwipe())
            {
                if (!isFirstSkipTry) //first one is to go to latest tutorial text. 
                {
                    Debug.Log("ilk skip denemesi");
                    pScreenManager.Next();
                    isFirstSkipTry = true;
                }
                else
                {
                    Debug.Log("ikinci skip denemesi");
                    isFirstSkipTry = false;
                    
                }
                
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
            else
            {
                Debug.Log("Screen swiped right");
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
