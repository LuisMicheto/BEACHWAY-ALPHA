using UnityEngine;

public class CopiarPosicion : MonoBehaviour
{
    public GameObject objetoOriginal;
    public GameObject objetoDestino;

    void Update()
    {
        // Obtener la posici�n del objeto original
        Vector3 originalPos = objetoOriginal.transform.position;

        // Crear una nueva posici�n con la misma posici�n en X e Y, pero la posici�n en Z del objeto original
        Vector3 nuevaPos = new Vector3(objetoDestino.transform.position.x, objetoDestino.transform.position.y, originalPos.z);

        // Asignar la nueva posici�n al objeto destino
        objetoDestino.transform.position = nuevaPos;
    }
}

