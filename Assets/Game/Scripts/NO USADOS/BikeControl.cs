using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public KeyCode brakeKey = KeyCode.Space;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize player position and movement
        transform.position = new Vector2(0, 0);
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if brake key is pressed
        if (Input.GetKeyDown(brakeKey))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        // Check if player reaches screen edge
        else if (transform.position.x > 10f || transform.position.x < -10f)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-GetComponent<Rigidbody2D>().velocity.x, 0);
        }
    }
}
