using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
   
    void Start()
    {
        // Invoke("RepositionRandomly", 4f);
        InvokeRepeating("RepositionRandomly", 1f, 1f);
    }

   
    void Update()
    {

    }

    void RepositionRandomly()
    {
        transform.localPosition = new Vector3(Random.Range(-1,2) ,0,0);
    }
}
