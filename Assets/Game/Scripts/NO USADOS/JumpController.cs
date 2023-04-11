using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{

    private float currentHeight = 0.0f; // the current height of the character
    private float jumpPhase = 0.0f; // the current phase of the jump
    private float jumpHeight = 3.0f; // the maximum height of the jump
    private float jumpDuration = 1.0f; // the duration of the jump

    public float colliderHeight = 1.0f; // the height of the character's collider

    private bool jumping = false; // whether the character is currently jumping

    private Rigidbody2D rb;
    private Collider2D coll;
    private Transform shadow;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        shadow = transform.GetChild(0); // assuming the shadow is the first child of the character
        shadow.gameObject.SetActive(false);
    }

    void Update()
    {
        // check for jump input and start jump if not already jumping
        if (Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            jumping = true;
            StartCoroutine(Jump());
        }

        // move horizontally based on input
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 position = transform.position;
        position.x += horizontal * Time.deltaTime;
        transform.position = position;
    }

    IEnumerator Jump()
    {
        // start jump animation
        shadow.gameObject.SetActive(true);
        float timer = 0.0f;

        while (timer < jumpDuration)
        {
            float normalizedTime = timer / jumpDuration;
            float jumpHeightOffset = jumpHeight * Mathf.Sin(normalizedTime * Mathf.PI);
            jumpPhase = jumpHeightOffset / jumpHeight;
            shadow.localScale = Vector3.one * (1.0f + jumpPhase);
            currentHeight = jumpHeightOffset;
            timer += Time.deltaTime;
            yield return null;
        }

        // end jump animation
        shadow.gameObject.SetActive(false);
        jumping = false;
        currentHeight = 0.0f;
        jumpPhase = 0.0f;
    }

    void FixedUpdate()
    {
        // calculate position with jump offset
        Vector2 position = rb.position;
        position.y = currentHeight + colliderHeight + jumpPhase;
        rb.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // check for collision with objects higher than current height + jump phase
        if (currentHeight + jumpPhase + colliderHeight <= collision.gameObject.GetComponent<Collider2D>().bounds.min.y)
        {
            return;
        }

        // adjust current height and jump phase if collision occurred
        float heightDifference = collision.gameObject.GetComponent<Collider2D>().bounds.max.y - currentHeight - colliderHeight;
        currentHeight += heightDifference;
        jumpPhase -= heightDifference;
    }
}
