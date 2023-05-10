using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTaker : MonoBehaviour
{
    public string target_tag = "Player";
    public int damage;
    public CameraShake cameraShake;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<LifeController>().Damage(damage);
            cameraShake.ShakeCamera(); 
        }
    }
   
}
