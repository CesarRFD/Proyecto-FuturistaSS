using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Vision : MonoBehaviour
{
    private BoxCollider2D playerCollider;
    private bool enemigoVisto = false;
    
    void Start()
    {
        playerCollider = GameObject.Find("Player").GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == playerCollider.gameObject)
        {
            enemigoVisto = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == playerCollider.gameObject)
        {
            enemigoVisto = false;
        } 
    }
    public bool EnemigoVisto()
    {
        return enemigoVisto;
    }
}
