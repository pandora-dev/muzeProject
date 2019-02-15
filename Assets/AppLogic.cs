using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AppLogic : MonoBehaviour
{

    private PUFScreenManager pScreenManager;
    public int tutorialHorizontalScrollStepCount;
    public HorizontalScrollSnap tutorialHorizontalScrollSnap;
    public PaginationManager tutorialPaginationManager;
    public ButtonOneClickable ARButton;
    public ARButtonState arButtonState; 
    public enum ARButtonState { OPEN,CLOSE};

    GraphicRaycaster m_Raycaster;
    EventSystem m_EventSystem;
    PointerEventData m_PointerEventData;


    public void Start()
    {

        pScreenManager = this.GetComponent<PUFScreenManager>();
        pScreenManager.OnScreenSwiped += ScreenSwiped;
        m_Raycaster = GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();

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

    public void Update()
    {
        /*
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            m_Raycaster.Raycast(m_PointerEventData, results);

            foreach (RaycastResult result in results)
            {
                if(result.gameObject.name)
                Debug.Log("Hit " + result.gameObject.name);
            }
        }
        */
    }

    public void ARButtonUp()
    {
        ARButton.GetComponent<Animator>().SetTrigger("ARTriggered");
        arButtonState = ARButtonState.OPEN;
    }
    public void ARButtonDown()
    {
        pScreenManager.views[1].GetComponent<Animator>().SetTrigger("ARTriggered");
        arButtonState = ARButtonState.CLOSE;
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
