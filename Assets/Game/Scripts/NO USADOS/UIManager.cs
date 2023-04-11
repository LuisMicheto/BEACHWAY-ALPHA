using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI puntuacion;
    public TextMeshProUGUI tiempo;
    public TextMeshProUGUI vidas;
    public TextMeshProUGUI gameover;

    public GameObject startButton;

    public float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        //puntuacion.text = GameManager.instance.puntuacion.ToString();
        //vidas.text = GameManager.instance.vidas.ToString();
        tiempo.text = (Time.time - startTime).ToString("00.00");

        //    if (GameManager.instance.vidas <= 0)
        //    {
        //        gameover.gameObject.SetActive(true);
        //    }
    }

    public void StartGame()
    {
        Debug.Log("Game Started");
        startButton.SetActive(false);
        //GameManager.instance.StartGame();
    }

    //public void RestartGame()
    //{
    //    Debug.Log("Game Re-Started");
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}
}
