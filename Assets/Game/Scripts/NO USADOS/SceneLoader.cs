using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string Tag = "Player";
    public UnityEvent onEnter;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Salir()
    {
        Debug.Log("He Salido");
        Application.Quit();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Tag)
        {
            onEnter.Invoke();
        }
    }

}
