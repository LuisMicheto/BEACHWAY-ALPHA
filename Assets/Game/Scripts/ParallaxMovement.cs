using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMovement : MonoBehaviour
{
    [SerializeField] private float parallaxMultipier;

    private Transform camTransform;
    private Vector3 previusCameraPosition;

    private void Start()
    {
        camTransform = Camera.main.transform;
        previusCameraPosition = camTransform.position;
    }

    private void Update()
    {
        float deltax = (camTransform.position.x - previusCameraPosition.x) * parallaxMultipier;
        transform.Translate(new Vector3(deltax, 0, 0));
        previusCameraPosition = camTransform.position;
    }
}
//{
//    public Camera cam;
//    public float speed;
//    public Vector3 offset;
//    // Start is called before the first frame update
//    void Start()
//    {
//        cam = Camera.main;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        transform.position = cam.transform.position * speed + offset;
//    }
//}
