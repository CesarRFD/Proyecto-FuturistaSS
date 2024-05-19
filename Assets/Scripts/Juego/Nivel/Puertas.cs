/*

Este script se encarga de mover al jugador a la posición de la puerta destino cuando el jugador presiona la tecla E y está tocando la puerta.

El BoxCollider puertaDestino es un BoxCollider2D que se asigna en el inspector y representa la puerta a la que se moverá el jugador.

player es un BoxCollider2D que representa al jugador.
puerta es un BoxCollider2D que representa la puerta actual.
playerTransform es el Transform del jugador.
IsTouching es un booleano que indica si el jugador está tocando la puerta.

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Puertas : MonoBehaviour
{
    [SerializeField] private BoxCollider2D puertaDestino;
    private BoxCollider2D player;
    private BoxCollider2D puerta;
    private bool IsTouching = false;
    private Transform playerTransform;
    void Start()
    {
        puerta = GetComponent<BoxCollider2D>();
        player = GameObject.Find("Player").GetComponent<BoxCollider2D>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    
    void Update()
    {
        if (IsTouching && Input.GetKeyDown(KeyCode.E))
        {
            playerTransform.position = new Vector3(puertaDestino.transform.position.x + 1.25f, puertaDestino.transform.position.y - 1.5f, puertaDestino.transform.position.z);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            IsTouching = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            IsTouching = false;
        }
    }
}
