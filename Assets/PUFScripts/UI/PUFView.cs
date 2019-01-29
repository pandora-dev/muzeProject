using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUFView : MonoBehaviour
{
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
    private bool isActive;

}
