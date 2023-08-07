using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    GameManager gameManager;

    public GameObject Player;

    public float sensitivity;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        gameManager._isGameStarted = true;
        Player.GetComponent<PlayerCont>().anim.SetBool("_isRunning", true);
    }


    public void OnDrag(PointerEventData eventData)
    {
        Player.transform.position += new Vector3(eventData.delta.x * sensitivity * Time.deltaTime, 0, 0);
    }


    public void Restart()
    {
        //OYUNU YENIDEN BASLAT

        SceneManager.LoadScene("Task5");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
