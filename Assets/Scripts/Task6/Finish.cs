using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Finish : MonoBehaviour
{
    public TextMeshPro TMP_FinishCount;
    public int FinishCount;


    void Start()
    {

    }

    void Update()
    {
        CheckText();
    }

    void CheckText()
    {
        TMP_FinishCount.text = FinishCount.ToString();
    }
}
