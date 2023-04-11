using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target; // The object that the camera should follow
    public float smoothing = 5f; // The speed with which the camera should follow the target
    public Vector3 offset; // The distance between the camera and the target

    private void Start()
    {
        // Calculate the initial offset
        offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        // Calculate the target position
        Vector3 targetCamPos = target.position + offset;
        // Limit the target position along the y-axis
        targetCamPos.y = transform.position.y;
        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}

//public class FollowCam : MonoBehaviour
//{
//    public Transform target; // The object that the camera should follow
//    public float smoothing = 5f; // The speed with which the camera should follow the target
//    public Vector3 offset; // The distance between the camera and the target

//    // Camera shake variables
//    public float shakeDuration = 0.1f; // The duration of the shake effect
//    public float shakeMagnitude = 0.1f; // The magnitude of the shake effect
//    private float shakeTimer = 0f; // The timer for the shake effect
//    private Vector3 initialPosition; // The initial position of the camera

//    private void Start()
//    {
//        // Calculate the initial offset
//        offset = transform.position - target.position;
//        // Set the initial position of the camera
//        initialPosition = transform.position;
//    }

//    private void FixedUpdate()
//    {
//        // Calculate the target position
//        Vector3 targetCamPos = target.position + offset;
//        // Limit the target position along the y-axis
//        targetCamPos.y = transform.position.y;

//        // If the player is accelerating, shake the camera
//        if (target.GetComponent<Rigidbody>().velocity.magnitude > 10f)
//        {
//            // Set the timer for the shake effect
//            shakeTimer = shakeDuration;
//        }

//        // Apply the camera shake effect
//        if (shakeTimer > 0)
//        {
//            // Move the camera position randomly
//            transform.position = initialPosition + Random.insideUnitSphere * shakeMagnitude;

//            // Decrease the timer for the shake effect
//            shakeTimer -= Time.deltaTime;
//        }
//        else
//        {
//            // Smoothly move the camera towards the target position
//            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
//        }
//    }
//}