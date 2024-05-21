/*
Este Script Se Encarga De Mover Al Enemigo Hacia El Jugador O Hacia Su Zona De Patrulla.
Debe colocarse en el GameObject Con El Nombre "Enemy_Agent".
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy_Agent : MonoBehaviour
{
    [Header("Variables De Patrulla.")]
    private float speed = 0.01f;//Velocidad De Movimiento Del Enemigo.
    [SerializeField] private Transform[] puntosMovimiento;//Puntos De Movimiento De Patrulleo Del Enemigo.
    private float distanciaMinima = 0.5f;//Distancia Minima Para Cambiar De Punto De Patrulla.
    private int numeroAleatorio;//Numero Aleatorio Para Cambiar De Punto De Patrulla.

    [Header("Imports.")]
    private Vision vision;
    private Rigidbody2D enemyRB;
    private Rigidbody2D playerRB;

    [Header("Logica General.")]
    private bool MovingToPlayer = false;//Variable Para Saber Si El Enemigo Se Esta Moviendo Hacia El Jugador.

    void Start()
    {
        /////////////////////////////////////////////////////////////////
        ///Importaciones.
        enemyRB = GetComponent<Rigidbody2D>();
        playerRB = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        vision = GetComponentInChildren<Vision>();
        numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
    }

    void Update()
    {
        /////////////////////////////////////////////////////////////////
        ///Este switch se encarga de saber si el enemigo ve al jugador o no, y en base a eso mueve al enemigo hacia el jugador o hacia su zona de patrulla.
        switch(vision.EnemigoVisto()){
            case true:
                if (vision.EnemigoVisto() && !MovingToPlayer) StartCoroutine(MoveTowardsPlayer());//Si el enemigo ve al jugador y no se esta moviendo hacia el jugador, entonces se mueve hacia el jugador.
            break;

            case false:
                float direction;//Esta variable se encarga de cambiar la direccion del enemigo.

                /////////////////////////////////////////////////////////////////
                ///Este if valida si el enemigo se esta moviendo hacia el jugador, si no se esta moviendo hacia el jugador, entonces se mueve hacia su zona de patrulla.
                if(MovingToPlayer == false){
                    transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[numeroAleatorio].position, speed);//Se mueve hacia el punto de patrulla actual.
                    direction = Mathf.Sign(puntosMovimiento[numeroAleatorio].position.x - enemyRB.position.x);//Se guarda el valor de la direccion del punto de patrulla actual con respecto al enemigo.
                    enemyRB.transform.localScale = new Vector3(direction, 1, 1);//Se cambia la direccion del enemigo con respecto al punto de patrulla actual.
                

                    /////////////////////////////////////////////////////////////////
                    ///Este if se encarga de cambiar el punto de patrulla del enemigo.
                    if (Vector2.Distance(transform.position, puntosMovimiento[numeroAleatorio].position) < distanciaMinima)
                        numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
                }
            break;
        }

    }
    //Corrutina Para Mover Al Enemigo Hacia El Jugador.
    IEnumerator MoveTowardsPlayer()
    {
        float directionPlayer;//Esta variable se encarga de cambiar la direccion del enemigo, aqui se guarda el valor de la direccion del jugador con respecto al enemigo.
        float elapsedTime = 0;//Esta variable se encarga de contar el tiempo que ha pasado desde que se inicio el ciclo.
        MovingToPlayer = true;//Esta variable se encarga de saber si el enemigo se esta moviendo hacia el jugador, sirve para evitar que el enemigo se mueva hacia el jugador mientras ya se esta moviendo hacia el jugador.
        while (elapsedTime < 5f)
            {
            directionPlayer = Mathf.Sign(playerRB.position.x - enemyRB.position.x);//Se guarda el valor de la direccion del jugador con respecto al enemigo.
            enemyRB.transform.localScale = new Vector3(directionPlayer, 1, 1);//Se cambia la direccion del enemigo.
            elapsedTime += Time.deltaTime;//Se suma el tiempo que ha pasado desde que se inicio el ciclo.

            /////////////////////////////////////////////////////////////////
            ///Con este codigo se mueve el enemigo hacia el jugador.
            enemyRB.transform.position = new Vector2(Mathf.MoveTowards(enemyRB.transform.position.x, playerRB.transform.position.x, speed*3),enemyRB.transform.position.y);

            yield return null;//Si
        }
        MovingToPlayer = false;//Se cambia la variable MovingToPlayer a false para que el enemigo pueda volver a moverse hacia el jugador o hacia su zona de patrulla.
    }
}