using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableColliderOnJump : MonoBehaviour
{
    private CapsuleCollider2D coll2D;
    public Transform referenceObject;
    public float posY;
    public float posYbike;
    public Button botonSalto;

    void Start()
    {
        coll2D = GetComponent<CapsuleCollider2D>();              
    }

    void Update()
    {
        posYbike = transform.position.y;
        if (referenceObject.transform.position.y < posYbike)
        {
            coll2D.enabled = false;
            botonSalto.interactable = false;
        }
        if (referenceObject.transform.position.y > posYbike)
        {
            coll2D.enabled = true;
            botonSalto.interactable = true;
        }        
    }
}