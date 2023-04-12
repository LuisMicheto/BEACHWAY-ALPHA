using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableColliderOnJump : MonoBehaviour
{
    private CapsuleCollider2D coll2D;
    public float posY;

    void Start()
    {
        // Obtenemos el componente Collider2D del objeto
        coll2D = GetComponent<CapsuleCollider2D>();
        // Guardamos la posición inicial del personaje
        posY = transform.position.y;
    }

    void Update()
    {
        // Si el personaje está saltando (su posición en Y es mayor que la anterior), desactivamos el collider
        if (transform.position.y > posY)
        {
            coll2D.enabled = false;
        }
        if (transform.position.y < posY)
        {
            coll2D.enabled = true;
        }

        // Guardamos la posición actual del personaje para compararla en la siguiente actualización del frame
        //previousYPosition = transform.position.y;
    }
}


