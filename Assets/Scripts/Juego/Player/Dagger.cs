using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Dagger : MonoBehaviour
{
    private Vision vision;
    private bool contact;
    private GameObject enemyInContact;
    void Start()
    {
        vision = GameObject.Find("Vision").GetComponent<Vision>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && contact && vision.EnemigoVisto() == false)Destroy(enemyInContact);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            contact = true;
            enemyInContact = collision.gameObject;
        }
        else
        {
            contact = false;
            enemyInContact = null;
        }
    }
}
