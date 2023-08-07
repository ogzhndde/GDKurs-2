using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float normalSpeed;
    public float boostedSpeed;

    public bool _isGameStarted = false;



    void Start()
    {
        speed = normalSpeed;
    }


    void Update()
    {
        Move();
    }


    void Move()
    {
        if (_isGameStarted == true)
        {
            transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpeedUp")
        {
            StartCoroutine(SpeedUp());
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Ghost"))
        {
            StartCoroutine(Ghost());
            Destroy(other.gameObject);
        }
    }


    IEnumerator SpeedUp()
    {
        speed = boostedSpeed;

        yield return new WaitForSeconds(4f);

        speed = normalSpeed;
    }


    IEnumerator Ghost()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.red;

        yield return new WaitForSeconds(4f);

        GetComponent<BoxCollider>().enabled = true;
        GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.white;

    }

}
