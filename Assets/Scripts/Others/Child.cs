using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour
{
    public Transform parentObject;

    void Start()
    {
        transform.SetParent(parentObject);
        
    }

    
}
