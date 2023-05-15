using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject game;

    public int vidas;
    //public int puntuacion = 0;

    void Awake()
    {
        instance = this;
        Time.timeScale = 0;
    }
    public void StartGame()
    {
        game.SetActive(true);
        Time.timeScale = 1;
    }
}