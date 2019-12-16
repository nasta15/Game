using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public bool trig = false;
    public Transform playerPosition;
    public Transform cameraPosition;
    public GameObject text;

    void Start()
    {
        text.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && trig)
        {
            GameObject.FindObjectOfType<Walking>().transform.position = playerPosition.position;
            Camera.main.gameObject.transform.position = cameraPosition.position - 10 * Vector3.forward;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Walking>() != null)//если этот кто-то это объект со скриптом move, т.е. персонаж 
        {
            text.SetActive(true);//то текст становится виден, когда подходишь к двери
            trig = true;//и срабатывает триггер перс в движении, для того чтобы сработала кнопка F
        }
    }

    private void OnTriggerExit2D(Collider2D other)//когда кто-то выходит из коллайдера двери
    {
        if (other.GetComponent<Walking>() != null)//и если этот кто-то - это персонаж
        {
            trig = false;// то выключается триггер, т.е. перс не движется
            text.SetActive(false);//и текст становится не виден, когда отходишь от двери
        }
    }
}
