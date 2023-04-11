using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 vector3 = transform.position;
        vector3.z = vector3.y;
        transform.position = vector3;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector3 = transform.position;
        vector3.z = vector3.y;
        transform.position = vector3;
    }
}
