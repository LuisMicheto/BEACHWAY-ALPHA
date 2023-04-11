using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chekpoint : MonoBehaviour
{
    public Transform checkpoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                LifeController lifeController = playerObject.GetComponent<LifeController>();
                if (lifeController != null)
                {
                    lifeController.checkpoint = checkpoint;
                }
            }
        }
    }
}
