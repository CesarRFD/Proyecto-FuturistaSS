using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private GameObject creditos;
    [SerializeField] private GameObject opciones;
    public void Jugar()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Juego");
    }

    public void ActivarOpciones()
    {
        opciones.SetActive(!opciones.activeSelf);
    }

    public void ActivarCreditos()
    {
        creditos.SetActive(!creditos.activeSelf);
    }

    public void Salir()
    {
        Application.Quit();
    }
}