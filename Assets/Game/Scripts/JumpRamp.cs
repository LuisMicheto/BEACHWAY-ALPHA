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
    AudioSource audioSource;

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
                animPlayer.SetBool("RampJump", true);
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
            }
        }
        }
}

