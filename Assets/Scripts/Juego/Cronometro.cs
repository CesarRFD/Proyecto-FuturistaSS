using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cronometro : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoCronometro;
    private float tiempo = 0.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        textoCronometro.text = Mathf.Floor(tiempo).ToString();
    }
}
