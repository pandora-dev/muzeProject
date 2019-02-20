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
    public bool emulateWithMouse;
    public Animator mainPageTitleAnimController;
    public Animator thumbnailButtonAnimController;
    public Animator arCameraHeaderAnimController;
    public GameObject tutorialButton;
    public GameObject backgroundPanel;
    public GameObject arBackButton;
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
        arBackButton.SetActive(false);

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


        m_PointerEventData = new PointerEventData(m_EventSystem);
        if (emulateWithMouse)
        {
            if(Input.GetMouseButtonDown(0))
            {
                m_PointerEventData.position = Input.mousePosition;
                if (arButtonState == ARButtonState.OPEN)
                {
                    if (IsInsideClickForARButton())
                        RunAR();
                    else
                        ARButtonDown();
                }
            }

        }
        else if(Input.touches.Length > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    m_PointerEventData.position = touch.position;
                    if(arButtonState==ARButtonState.OPEN)
                    {
                        if (IsInsideClickForARButton())
                            RunAR();
                        else
                            ARButtonDown();
                    }
                }
            }
                    
        }

        
            
        
        
        
        
    }

    private bool IsInsideClickForARButton()
    {
        bool ARClickFound = false;
        List<RaycastResult> results = new List<RaycastResult>();
        m_Raycaster.Raycast(m_PointerEventData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.name == "ARButton")
                ARClickFound = true;
        }
        return ARClickFound;
    }

    public void RunAR()
    {
        
        mainPageTitleAnimController.SetBool("HasFade", true);
        thumbnailButtonAnimController.SetBool("HasFade", true);
        ARButtonDown();
        ARButton.GetComponent<Animator>().SetBool("HasFade", true);
        arCameraHeaderAnimController.SetBool("HasFade", true);
        tutorialButton.SetActive(false);
        pScreenManager.views[1].GetComponent<Animator>().SetBool("isTransparent", true);
        backgroundPanel.SetActive(false);
        arBackButton.SetActive(true);
        arBackButton.GetComponent<Animator>().SetBool("HasFade", true);
        

        
    }

    public void ExitAR()
    {
        arCameraHeaderAnimController.SetBool("HasFade", false);
        pScreenManager.views[1].GetComponent<Animator>().SetBool("isTransparent", false);
        mainPageTitleAnimController.SetBool("HasFade", false);
        thumbnailButtonAnimController.SetBool("HasFade", false);
        ARButton.GetComponent<Animator>().SetBool("HasFade", false);
        tutorialButton.SetActive(true); 
        arBackButton.GetComponent<Animator>().SetBool("HasFade", false);
        arBackButton.SetActive(false);
    }




    public void ARButtonUp()
    {
        ARButton.GetComponent<Animator>().SetBool("ARCancel", false);
        ARButton.GetComponent<Animator>().SetBool("ARTrigger",true);
        arButtonState = ARButtonState.OPEN;
    }
    public void ARButtonDown()
    {
        ARButton.GetComponent<Animator>().SetBool("ARTrigger", false);
        ARButton.GetComponent<Animator>().SetBool("ARCancel",true);
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
