using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanController : MonoBehaviour
{
    public FloatingJoystick floatingJoystick;
    public GameObject bg;
    public float speed;

    public Animator anim;

    public GameObject prefab;

    public Transform stackPoint;
    public Material stickmanMat;

    public bool _isLastBoxTaken = false;

    public int takeCount = 0;


    void Start()
    {
        // Instantiate(prefab, transform.position + new Vector3(0, 0, 3), Quaternion.identity);

        UIManager.instance.ScoreText.text = "Score: " + UIManager.instance.Score;

        StartCoroutine(MakeFaster());
    }

    public IEnumerator MakeFaster()
    {
        Debug.Log("Ilk kez");
        yield return new WaitForSeconds(3f);
        Debug.Log("Ikinci kez");
    }


    void Update()
    {
        if (bg.activeInHierarchy == true)
        {
            Vector3 direction = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;

            transform.position += direction * speed * Time.deltaTime;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 10f * Time.deltaTime);

            anim.SetBool("_isRunning", true);
        }
        else
        {
            anim.SetBool("_isRunning", false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BlueDesk"))
        {
            if (transform.childCount < 4)
            {
                GameObject chosenBox = other.transform.GetChild(Random.Range(0, other.transform.childCount)).gameObject; //RASTGELE OBJE SECME

                chosenBox.transform.SetParent(transform); //SECILEN OBJEYI KENDI CHILDIM YAPIYORUM
                chosenBox.transform.localPosition = stackPoint.transform.localPosition; //SECILEN OBJENIN KONUMUNU DUZENLIYORUM

                transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = chosenBox.GetComponent<MeshRenderer>().material; //MATERIAL DEGISIMI

                if (other.transform.childCount == 0)
                {
                    _isLastBoxTaken = true;
                }
            }

        }

        if (other.tag == "RedDesk")
        {
            if (transform.childCount == 4)
            {
                GameObject stackedBox = transform.GetChild(transform.childCount - 1).gameObject; //EN SON CHILDIMI SECIYORUM

                stackedBox.transform.SetParent(other.transform); //Sirtimdaki objeyi masaya birakiyorum
                stackedBox.transform.localPosition = other.transform.localPosition + new Vector3(0, 0.5f * other.transform.childCount, 0);

                transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = stickmanMat; //MATERIAL DEGISTIRIYORUM

                UIManager.instance.Score++;
                UIManager.instance.ScoreText.text = "Score: " + UIManager.instance.Score;
            }
        }

        if (other.tag == "GreenDesk")
        {
            if (transform.childCount == 4)
            {
                GameObject stackedBox = transform.GetChild(transform.childCount - 1).gameObject;

                stackedBox.transform.SetParent(other.transform);
                stackedBox.transform.localPosition = other.transform.localPosition + new Vector3(0, 0.5f * other.transform.childCount, 0);

                transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = stickmanMat;

                UIManager.instance.Score++;
                UIManager.instance.ScoreText.text = "Score: " + UIManager.instance.Score;
            }
        }

    }


}
