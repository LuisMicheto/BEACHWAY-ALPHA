using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{
    public int life;
    public int life_max;
    private Rigidbody2D bikeRigidbody;
    public enum DeathMode { Destroy, lastChekpoint, SceneReload }
    public DeathMode deathMode = DeathMode.Destroy;
    public Transform checkpoint;

    public float deathDelay = 2.0f;      

    // Start is called before the first frame update
    void Start()
    {
        bikeRigidbody = GetComponent<Rigidbody2D>();
        life = life_max;
    }

    void Update()
    {
        
    }

    public void Damage(int amount)
    {
        life -= amount;

        if (life <= 0)
        {
            StartCoroutine(DeathWithDelay());
        }
    }

    IEnumerator DeathWithDelay()
    {
        // Pausar el tiempo en la escena
        Time.timeScale = 0f;        

        yield return new WaitForSecondsRealtime(deathDelay);

        // Reanudar el tiempo en la escena
        Time.timeScale = 1f;        

        Death();
    }

    public void Death()
    {
        if (deathMode == DeathMode.lastChekpoint)
        {
            life = life_max;
            transform.position = checkpoint.position;
            Debug.Log("Muerto. bikeRigidbody.simulated: " + bikeRigidbody.simulated);
        }
        if (deathMode == DeathMode.SceneReload)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
