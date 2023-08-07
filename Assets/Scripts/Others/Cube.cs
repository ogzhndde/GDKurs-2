using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Color cubeColor;
    public Material targetMat;

    public GameObject prefab;

    public int randomNumber;
    public int min, max;

    void Start()
    {

        randomNumber = Random.Range(min, max);

        for (int i = 0; i < Random.Range(5, 12); i++)
        {
            Instantiate(prefab, transform.position + new Vector3(0, 0, randomNumber), Quaternion.identity);
        }




    }


    void Update()
    {

    }
}
