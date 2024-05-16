using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [Header("Logica General.")]
    private Vision vision;
    private Rigidbody2D enemyRB;
private Rigidbody2D playerRB;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        playerRB = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        vision = GameObject.Find("Vision").GetComponent<Vision>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vision.EnemigoVisto()) enemyRB.transform.position = Vector2.MoveTowards(enemyRB.transform.position, playerRB.transform.position, 0.01f);
        
    }
}