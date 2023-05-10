using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustController : MonoBehaviour
{
    [SerializeField] ParticleSystem dustParticle;
    

    [Range(0, 10)]
    [SerializeField] int ocurAfterVelocity;
    
    [Range(0, 0.2f)]
    [SerializeField] float dustFormationPeriod;
    
    [SerializeField] Rigidbody2D playerRb;
    float counter;

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        if(Mathf.Abs(playerRb.velocity.x) >ocurAfterVelocity)
        {
            if(counter > dustFormationPeriod)
            {
                dustParticle.Play();
                counter = 0;
                
            }
        }        
    }
    
}
