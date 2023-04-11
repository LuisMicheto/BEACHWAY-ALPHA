using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Botella : MonoBehaviour
{
    public Button button; // Variable para almacenar el botón

    private void Start()
    {
        button.interactable = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            button.interactable = true; // Activar el botón
            gameObject.SetActive(false); // Desactivar el objeto actual
        }
    }
}