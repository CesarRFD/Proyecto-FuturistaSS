using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy_Agent : MonoBehaviour
{
    [Header("Variables De Patrulla.")]
    [SerializeField] private float velMovimiento;
    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private float distanciaMinima;
    private int numeroAleatorio;

    [Header("Logica General.")]
    [SerializeField] private Vision vision;
    private Rigidbody2D enemyRB;
    private Rigidbody2D playerRB;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        playerRB = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        vision = GetComponentInChildren<Vision>();

        ///
        numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
    }

    void Update()
    {
        if (vision.EnemigoVisto()) enemyRB.transform.position = Vector2.MoveTowards(enemyRB.transform.position, playerRB.transform.position, 0.01f);

        transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[numeroAleatorio].position, velMovimiento * Time.deltaTime);
        if (Vector2.Distance(transform.position, puntosMovimiento[numeroAleatorio].position) < distanciaMinima)
        {
            numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
            Girar();
        }
        
    }
    private void Girar()
    {
        if (transform.position.x < puntosMovimiento[numeroAleatorio].position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}



    

    

   

    



