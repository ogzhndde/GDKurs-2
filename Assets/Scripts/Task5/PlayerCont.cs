using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour
{
    public GameManager gameManager;
    public float speed;
    public float normalSpeed;

    public Animator anim;
    public Transform stackPoint;
    public List<GameObject> CollectedObjects;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        speed = normalSpeed;
    }


    void Update()
    {
        Move();
        ListSetTarget();
    }


    void Move()
    {
        if (gameManager._isGameStarted == true)
        {
            transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        }
    }

    public void CollectProcess(GameObject other)
    {
        other.tag = "Collected";

        if (!CollectedObjects.Contains(other.gameObject))
        {
            CollectedObjects.Add(other.gameObject);
        }
    }

    public void ObstacleProcess(GameObject other)
    {
        if (CollectedObjects.Contains(other.gameObject))
        {
            CollectedObjects.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
    }

    public void GateProcess(GameObject other)
    {
        if (CollectedObjects.Contains(other.gameObject))
        {
            GameObject particle = Instantiate(Resources.Load<GameObject>("GatePopParticle"), other.transform.position, Quaternion.identity);

            CollectedObjects.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
    }

    public void FinishProcess(GameObject other)
    {
        if (CollectedObjects.Contains(other.gameObject))
        {
            GameObject particle = Instantiate(Resources.Load<GameObject>("GatePopParticle"), other.transform.position, Quaternion.identity);

            CollectedObjects.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
    }


    public void ListSetTarget()
    {
        for (int i = 0; i < CollectedObjects.Count; i++)
        {
            if (i == 0)
            {
                CollectedObjects[i].GetComponent<Collect>().TargetObj = stackPoint;
            }
            else
            {
                CollectedObjects[i].GetComponent<Collect>().TargetObj = CollectedObjects[i - 1].transform;
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {

        switch (other.tag)
        {
            case "Finish":
                speed = 0;

                gameManager.CM_Player.SetActive(false);
                gameManager.CM_Finish.SetActive(true);
                break;
        }
    }



}
