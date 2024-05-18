using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Vision : MonoBehaviour
{
    private BoxCollider2D playerCollider;
    private Dagger dagger;
    private bool enemigoVisto;

    void Awake()
    {
        playerCollider = GameObject.Find("Player").GetComponent<BoxCollider2D>();
        dagger = GameObject.Find("Dagger").GetComponent<Dagger>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dagger.SetVistoTrue();
            enemigoVisto = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dagger.SetVistoFalse();
            enemigoVisto = false;
        }
    }

    public bool EnemigoVisto()
    {
        return enemigoVisto;
    }
}