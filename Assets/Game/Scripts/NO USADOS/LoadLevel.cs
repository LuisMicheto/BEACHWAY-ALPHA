using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void loadScene(string escena)
    //{
    //    Application.LoadLevel(escena);
    //}
    public void setactive(GameObject canvasactive)
    {
        canvasactive.SetActive(true);
    }

    public void setdesactive(GameObject canvasdesactive)
    {
        canvasdesactive.SetActive(false);
    }
}