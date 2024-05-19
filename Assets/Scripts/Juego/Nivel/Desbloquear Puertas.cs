using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DesbloquearPuertas : MonoBehaviour
{
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject puertaBloqueada;

    [SerializeField] private GameObject player;
    
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (Vector2.Distance(player.transform.position, key.transform.position) < 1.25f)
        {
            Destroy(key);
            Destroy(puertaBloqueada);
        }
    }
    
}
