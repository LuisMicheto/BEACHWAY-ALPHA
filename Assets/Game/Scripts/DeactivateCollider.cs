using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateCollider : MonoBehaviour
{
    public Transform referenceObject;
    public float thresholdY;
    private CapsuleCollider2D coll2D;

    private void Start()
    {
        coll2D = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        if (transform.position.y - referenceObject.position.y < thresholdY)
        {
            coll2D.enabled = false;
        }
        if (transform.position.y - referenceObject.position.y > thresholdY)
        {
            coll2D.enabled = true;
        }
    }
}
