using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gate : MonoBehaviour
{
    public TextMeshPro TMP_GateCount;
    public int GateCount;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        TextCheck();
    }

    public void TextCheck()
    {
        if (GateCount > 0)
        {
            TMP_GateCount.text = GateCount.ToString();
        }
        else
        {
            TMP_GateCount.text = "Kapilar Acildi!";
        }

    }

    public void GateOpenProcess()
    {
        anim.SetBool("_isGateOpen", true);

        Destroy(GetComponent<BoxCollider>());
        // GetComponent<BoxCollider>().enabled = false;
    }

}
