using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    public float speed = 2f; // Speed of the enemy's movement
    public float distance = 2f; // Distance the enemy will move up and down

    private float startingY; // Starting Y position of the enemy

    void Start()
    {
        startingY = transform.position.y;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * speed) * distance + startingY;
        transform.position = new Vector2(transform.position.x, newY);
    }
}
