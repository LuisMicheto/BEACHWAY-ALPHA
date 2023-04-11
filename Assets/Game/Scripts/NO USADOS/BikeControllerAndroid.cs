using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeControllerAndroid : MonoBehaviour
{
    public float moveSpeed;
    public float moveUpDown;

    public float boostSpeed;
    public float boostDuration;
    

    private Rigidbody2D bikeRigidbody;
    private Coroutine boostCoroutine;

    void Start()
    {
        bikeRigidbody = GetComponent<Rigidbody2D>();
        
       
    }

    public void MoveUp()
    {
        bikeRigidbody.velocity = Vector2.up * moveSpeed;
    }

    public void MoveDown()
    {
        bikeRigidbody.velocity = Vector2.up * -moveSpeed;
    }

    public void StopMoving()
    {
        bikeRigidbody.velocity = Vector2.zero;
    }

    public void Boost()
    {
        if (boostCoroutine != null)
        {
            StopCoroutine(boostCoroutine);
        }
        boostCoroutine = StartCoroutine(BoostForDuration(boostDuration));
    }

    private IEnumerator BoostForDuration(float duration)
    {
        float initialSpeed = moveSpeed;
        moveSpeed = boostSpeed;
        yield return new WaitForSeconds(duration);
        moveSpeed = initialSpeed;
    }

    void Update()
    {
        bikeRigidbody.velocity = new Vector3(moveSpeed, bikeRigidbody.velocity.y, Time.deltaTime * moveSpeed);
    }
}

