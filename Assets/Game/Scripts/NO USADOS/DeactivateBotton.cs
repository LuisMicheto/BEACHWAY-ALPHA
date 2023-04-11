using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeactivateBotton : MonoBehaviour
{
    public Transform referenceObject;
    public float thresholdY = 0f;
    public Button botonSalto;

    void Update()
    {

        if (transform.position.y - referenceObject.position.y > thresholdY)
            {

            Debug.Log(transform.position.y+ "false");
            botonSalto.interactable = false;
        }
        if (transform.position.y - referenceObject.position.y <= thresholdY)
        {
            botonSalto.interactable = true;
        }
    }
}


