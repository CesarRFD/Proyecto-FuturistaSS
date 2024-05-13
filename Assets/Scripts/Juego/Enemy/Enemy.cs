using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Logica General.")]
    private bool enemigoVisto = false;
    private BoxCollider2D ConoVision;
    void Start()
    {
        ConoVision = GameObject.Find("Vision").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enemigoVisto = true;
            Debug.Log("Enemigo Visto");
        }
        
    }

}