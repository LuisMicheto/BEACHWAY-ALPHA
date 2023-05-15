using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateCollider : MonoBehaviour
{
    public Transform referenceObject;

    public float thresholdY;
    private CapsuleCollider2D coll2D;
    public float posYbike;

    private void Start()
    {
        coll2D = GetComponent<CapsuleCollider2D>();        
    }

    private void Update()
    {
        posYbike = transform.position.y;
        if (posYbike - referenceObject.position.y < thresholdY)
        {
            coll2D.enabled = false;
        }
        if (posYbike - referenceObject.position.y > thresholdY)
        {
            coll2D.enabled = true;
        }
    }
}
