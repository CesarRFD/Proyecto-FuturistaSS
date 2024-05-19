using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Dagger : MonoBehaviour
{
    private GameObject enemyInContact;
    private bool contact;
    private bool vision;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && contact && vision == false) Destroy (enemyInContact);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            contact = true;
            enemyInContact = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            contact = false;
            enemyInContact = null;
        }
    }
    public void SetVistoTrue(){
        vision = true;
    }
    public void SetVistoFalse(){
        vision = false;
    }
}
