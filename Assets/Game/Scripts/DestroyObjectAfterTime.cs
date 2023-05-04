using UnityEngine;

public class DestroyObjectAfterTime : MonoBehaviour
{
    public float timeToDestroy; // Tiempo en segundos antes de destruir el objeto

    private void Start()
    {
        // Destruye el objeto después del tiempo especificado
        Destroy(gameObject, timeToDestroy);
    }
}

