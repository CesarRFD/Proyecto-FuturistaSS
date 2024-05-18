using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Logica General.")]
    private float horizontal;//Variable Para Moverse.
    //private bool walking;//Logica De SFX.
    //private bool playing = true;//Logica De SFX.
    public int tecladoOMovil = 1;//Logica Para Teclado O Movil.

    [Header("Archivos De Lectura.")]
    [SerializeField] private float speed = 3;
    //static private readonly float torque = 1f;
    static private readonly float fuerzaSalto = 5f;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        //transform.Translate(horizontal * speed * Time.deltaTime, 0, 0);
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if (horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (horizontal > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
        }
    }
}
