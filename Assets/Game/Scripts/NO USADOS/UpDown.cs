using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpDown : MonoBehaviour
{
    public float speed = 1f;
    private new Transform transform;
    private Vector2 position;
    private bool isUp = false;
    private bool isDown = false;
    

    private void Start()
    {
        transform = GetComponent<Transform>();
        
    }
    public void UpButton()
    {
        if (!isUp)
        {
            isUp = true;
            isDown = false;
        }
    }

    public void DownButton()
    {
        if (!isDown)
        {
            isDown = true;
            isUp = false;
        }
    }

    private void Update()
    {
        position = base.transform.position;

        if (isUp)
        {
            position.y += speed * Time.deltaTime;
        }
        else if (isDown)
        {
            position.y -= speed * Time.deltaTime;
        }
        else
        {
            isUp = false;
            isDown = false;
        }

        base.transform.position = position;
    }

    public void StopMoving()
    {
        
    }
}
