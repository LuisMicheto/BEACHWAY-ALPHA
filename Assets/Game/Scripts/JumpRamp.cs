using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JumpRamp : MonoBehaviour
{
    public float jumpTime = 1f;
    public float jumpHeight = 5f;
    public Transform constraintObject;
    private float jumpTimer = 0f;
    private bool isJumping = false;
    public Vector3 startPos;
    public Transform sombra;
    public Animator anim;
    public Animator animPlayer;
    public GameObject dustParticlePrefab;
    AudioSource audioSource;
    public AudioClip audioFall;
    public AudioClip audioFuerza;

    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        animPlayer = GameObject.Find("PlayerMountain").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("JumpTrigger"))
        {
            if (!isJumping)
            {
                //startPos = transform.localPosition;
                isJumping = true;
                anim.SetBool("JumpRamp", true);
                anim.SetBool("CiudadJumpRamp", true);
                anim.SetBool("CarreteraumpRamp", true);
                animPlayer.SetBool("RampJump", true);
                audioSource.PlayOneShot(audioFuerza);

            }
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
                anim.SetBool("JumpRamp", false);
                animPlayer.SetBool("RampJump", false);
                anim.SetBool("CiudadJumpRamp", false);
                anim.SetBool("CarreteraumpRamp", false);
                EmitDustParticle();
                audioSource.PlayOneShot(audioFall);
            }
        }
        }
    private void EmitDustParticle()
    {

        Vector2 particlePosition = new Vector2(transform.position.x + 1f, transform.position.y - 1f);
        GameObject dustParticles = Instantiate(dustParticlePrefab, particlePosition, Quaternion.identity);
        Destroy(dustParticles, 2f);
    }
}

