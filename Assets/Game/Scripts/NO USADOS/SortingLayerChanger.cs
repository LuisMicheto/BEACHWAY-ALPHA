using UnityEngine;

public class SortingLayerChanger : MonoBehaviour
{
    // Los sorting layers que queremos cambiar en función del eje Y
    public string sortingLayerNameLow;
    public string sortingLayerNameHigh;

    // La altura del personaje en la que se cambia el sorting layer
    public float heightThreshold = 0f;

    // Referencia al transform del objeto
    private Transform bikeTransform;

    // Referencia al renderer del objeto
    private Renderer bikeRenderer;

    // En el inicio del script, obtenemos las referencias al transform y al renderer del objeto
    void Start()
    {
        bikeTransform = GetComponent<Transform>();
        bikeRenderer = GetComponent<Renderer>();
    }

    // En cada frame, comprobamos la altura del personaje y cambiamos el sorting layer si es necesario
    void Update()
    {
        // Si la altura del personaje es mayor que la altura umbral, cambiamos el sorting layer al de la capa superior
        if (transform.position.y > heightThreshold)
        {
            bikeRenderer.sortingLayerName = sortingLayerNameHigh;
        }
        // Si la altura del personaje es menor o igual que la altura umbral, cambiamos el sorting layer al de la capa inferior
        else
        {
            bikeRenderer.sortingLayerName = sortingLayerNameLow;
        }
    }
}

