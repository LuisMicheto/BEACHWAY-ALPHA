using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayerCopier : MonoBehaviour
{
    public GameObject sourceObject;
    private Renderer myRenderer;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
    }

    void LateUpdate()
    {
        if (sourceObject != null)
        {
            myRenderer.sortingLayerName = sourceObject.GetComponent<Renderer>().sortingLayerName;
            myRenderer.sortingOrder = sourceObject.GetComponent<Renderer>().sortingOrder;
        }
    }
}

