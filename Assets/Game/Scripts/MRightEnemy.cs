using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRightEnemy : MonoBehaviour
{
    public float horizontalSpeed = 3f; // speed of the enemy's horizontal movement
    public bool isActive = false; // indicates whether the enemy is active or not
    public string enemyActivatorTag = "LateEnemyActivator"; // tag of the object that will activate the enemy's horizontal movement

    void Start()
    {
        Vector3 vector3 = transform.position;
        vector3.z = vector3.y;
        transform.position = vector3;
    }
    // Update is called once per frame
    void Update()

    {
        // if the enemy is active, move it horizontally at the specified speed
        if (isActive)
        {
            transform.Translate(Vector2.right * horizontalSpeed * Time.deltaTime);           
            Vector3 vector3 = transform.position;
            vector3.z = vector3.y;
            transform.position = vector3;
        }
    }

    // Called when another collider enters this object's collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(enemyActivatorTag))
        {
            // If the collided object has the specified tag, activate the enemy's horizontal movement
            isActive = true;
        }
    }
}
