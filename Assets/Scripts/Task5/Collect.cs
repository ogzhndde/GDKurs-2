using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public Transform TargetObj;

    public GameObject Player;

    public Mesh cubeMesh;
    public Mesh sphereMesh;

    public bool _isCube;



    void Start()
    {
        // Player = FindObjectOfType<PlayerCont>().gameObject;

        Player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        GoTargetObj();

    }

    public void GoTargetObj()
    {
        if (TargetObj != null)
        {
            float x = Mathf.Lerp(transform.position.x, TargetObj.position.x, Time.deltaTime * 10f);
            float z = Mathf.Lerp(transform.position.z, TargetObj.position.z + 1f, Time.deltaTime * 20f);

            transform.position = new Vector3(x, transform.position.y, z);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerCont>().CollectProcess(gameObject);
        }

        if (other.tag == "Collected")
        {
            Player.GetComponent<PlayerCont>().CollectProcess(gameObject);
        }

        if (other.CompareTag("Obstacle"))
        {
            Player.GetComponent<PlayerCont>().ObstacleProcess(gameObject);
        }

        if (other.tag == "Gate")
        {
            other.GetComponent<Gate>().GateCount--;
            Player.GetComponent<PlayerCont>().GateProcess(gameObject);

            if (other.GetComponent<Gate>().GateCount <= 0)
            {
                other.GetComponent<Gate>().GateOpenProcess();
            }

        }

        if (other.tag == "Finish")
        {
            other.GetComponent<Finish>().FinishCount++;

            Player.GetComponent<PlayerCont>().FinishProcess(gameObject);
        }

    }




}
