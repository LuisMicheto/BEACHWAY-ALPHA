using Spine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jump : MonoBehaviour
{
    public float jumpTime = 1f;
    public float jumpHeight = 5f;
    public Transform constraintObject;
    private float jumpTimer = 0f;
    private bool isJumping = false;
    public Vector3 startPos;
    public Transform sombra;
    public Transform Bici;
    public Transform Altura;
    public Button botonSalto;
    public Animator anim;
    public Animator animPlayer;
    public AudioSource audioSource;
    public GameObject dustParticlePrefab; // Prefab de la part�cula de polvo

    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        animPlayer = GameObject.Find("PlayerMountain").GetComponent<Animator>();
        animPlayer = GameObject.Find("PlayerCarretera").GetComponent<Animator>();
        animPlayer = GameObject.Find("PlayerCiudad").GetComponent<Animator>();
    }

    public void JumpButton()
    {
        if (!isJumping)
        {
            isJumping = true;
            anim.SetBool("BikeJump", true);
            anim.SetBool("CiudadJump", true);
            anim.SetBool("CarreteraJump", true);
            animPlayer.SetBool("Jump", true);
        }
    }

    private void Update()
    {
        if (isJumping)
        {
            jumpTimer += Time.deltaTime;

            float t = jumpTimer / jumpTime;
            float y = Mathf.Sin(Mathf.PI * t) * jumpHeight;
            Vector3 newPos = new Vector3(sombra.position.x, sombra.position.y + y, sombra.position.z) + startPos;

            newPos.x = constraintObject.position.x;

            transform.position = newPos;

            if (jumpTimer >= jumpTime)
            {
                isJumping = false;
                jumpTimer = 0f;
                anim.SetBool("BikeJump", false);
                animPlayer.SetBool("Jump", false);
                anim.SetBool("CiudadJump", false);
                anim.SetBool("CarreteraJump", false);
                EmitDustParticle();              
                
            }
        }
    }

    private void FixedUpdate()
    {
        if (Bici.transform.position.y > Altura.transform.position.y)
        {
            botonSalto.interactable = false;
        }
        else
        {
            botonSalto.interactable = true;
        }
    }

    private void EmitDustParticle()
    {
        
        Vector2 particlePosition = new Vector2(transform.position.x + 1f, transform.position.y - 1f);            
        GameObject dustParticles = Instantiate(dustParticlePrefab, particlePosition, Quaternion.identity);        
        Destroy(dustParticles, 5f);
    }
}


