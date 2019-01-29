using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUFScreenManager : MonoBehaviour
{
    void Awake()
    {
        if(this.GetComponent<Canvas>()==null){
            Debug.LogError("This script must be attached into Canvas");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
