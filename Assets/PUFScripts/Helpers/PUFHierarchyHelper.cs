using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUFHierarchyHelper : MonoBehaviour
{
    public void Awake()
    {
        if(this.GetComponent<Transform>()!=null)
        {
            Debug.LogError("Helper classes can't be inserted into components");
        }
    }
    public static Transform[] ChildTransforms(Transform t)
    {
        return t.transform.GetComponentsInChildren<Transform>(true);
    }

}
