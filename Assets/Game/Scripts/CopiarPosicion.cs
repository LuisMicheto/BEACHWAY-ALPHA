using UnityEngine;

public class CopiarPosicion : MonoBehaviour
{
    public GameObject objetoOriginal;
    public GameObject objetoDestino;

    void Update()
    {
        // Obtener la posición del objeto original
        Vector3 originalPos = objetoOriginal.transform.position;

        // Crear una nueva posición con la misma posición en X e Y, pero la posición en Z del objeto original
        Vector3 nuevaPos = new Vector3(objetoDestino.transform.position.x, objetoDestino.transform.position.y, originalPos.z);

        // Asignar la nueva posición al objeto destino
        objetoDestino.transform.position = nuevaPos;
    }
}

