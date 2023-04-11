using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableColliderOnJump : MonoBehaviour
{
    private CapsuleCollider2D coll2D;
    private float previousYPosition;

    void Start()
    {
        // Obtenemos el componente Collider2D del objeto
        coll2D = GetComponent<CapsuleCollider2D>();
        // Guardamos la posici�n inicial del personaje
        previousYPosition = transform.position.y;
    }

    void Update()
    {
        // Si el personaje est� saltando (su posici�n en Y es mayor que la anterior), desactivamos el collider
        if (transform.position.y > previousYPosition)
        {
            coll2D.enabled = false;
        }
        if (transform.position.y < previousYPosition)
        {
            coll2D.enabled = true;
        }

        // Guardamos la posici�n actual del personaje para compararla en la siguiente actualizaci�n del frame
        //previousYPosition = transform.position.y;
    }
}


