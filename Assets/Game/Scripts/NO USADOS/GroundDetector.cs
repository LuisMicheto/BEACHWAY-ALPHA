using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool grounded;
    public string tagPlatform = "PlataformaMovil";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == tagPlatform)
        {
            transform.SetParent(collision.transform, true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        grounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false;
        if (collision.tag == tagPlatform)
        {
            transform.SetParent(null, true);
        }
    }
}
