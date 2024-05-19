using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Guard : MonoBehaviour
{
    [Header("Logica General.")]
    private Vision visionI;
    private Vision visionD;
    private Rigidbody2D enemyRB;
    private Rigidbody2D playerRB;
    [SerializeField] private float speed = 0.05f;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        playerRB = GameObject.Find("Player").GetComponent<Rigidbody2D>();

        Vision[] visions = GetComponentsInChildren<Vision>();
        if (visions.Length > 0)
        {
            visionI = visions[0];
            if (visions.Length > 1)
            {
                visionD = visions[1];
            }
        }
    }
    
    void Update()
    {
        if ((visionI != null && visionI.EnemigoVisto()) || (visionD != null && visionD.EnemigoVisto()))
        { 
            enemyRB.transform.position = Vector2.MoveTowards
            (enemyRB.transform.position, playerRB.transform.position, speed);
            Debug.Log("Enemigo Visto");
        }
    }
}