using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int score = 0;
    //public GameObject characterPrefab1;
    //public GameObject characterPrefab2;
    //public GameObject characterPrefab3;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null) 
        { 
            Instance = this;
            DontDestroyOnLoad(this);
            // Carga el primer prefab de personaje al iniciar la escena
            //Instantiate(characterPrefab1, transform.position, Quaternion.identity);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //public void LoadCharacter2()
    //{
    //    // Destruye el personaje actual
    //    Destroy(GameObject.FindGameObjectWithTag("Player"));

    //    // Carga el segundo prefab de personaje
    //    Instantiate(characterPrefab2, transform.position, Quaternion.identity);
    //}

    //// Método para cargar el tercer prefab de personaje
    //public void LoadCharacter3()
    //{
    //    // Destruye el personaje actual
    //    Destroy(GameObject.FindGameObjectWithTag("Player"));

    //    // Carga el tercer prefab de personaje
    //    Instantiate(characterPrefab3, transform.position, Quaternion.identity);
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
