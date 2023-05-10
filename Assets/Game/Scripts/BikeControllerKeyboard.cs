using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BikeControllerKeyboard : MonoBehaviour
{
    public float moveUpDown;
    private Rigidbody2D bikeRigidbody;
    public float moveSpeed;
    public float boostSpeed;
    public float boostDuration;
    private Coroutine boostCoroutine;
    public Slider boostSlider;
    private string BoostObjectTag = "BoostObject";
    public float boostFillAmount;
    public Animator animMountain;
    public Animator animCarretera;
    public Animator animCiudad;
    AudioSource audioSource;
    public AudioClip audioBoost;
    public AudioClip audioGolpe;
    public GameObject crashParticlePrefab;

    void Start()
    {
        bikeRigidbody = GetComponent<Rigidbody2D>();
        boostSlider.minValue = 0f;
        boostSlider.maxValue = 1f;
        boostSlider.value = 0;
        animMountain = GameObject.Find("BikeMountain").GetComponent<Animator>();
        animCarretera = GameObject.Find("BikeCarretera").GetComponent<Animator>();
        animCiudad = GameObject.Find("BikeCiudad").GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        Vector3 vector3 = transform.position;
        vector3.z = vector3.y;
        transform.position = vector3;
        if (Input.GetKeyDown(KeyCode.W))
        {
            bikeRigidbody.velocity = Vector3.down * -moveUpDown;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            bikeRigidbody.velocity = Vector3.up * -moveUpDown;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            bikeRigidbody.velocity = Vector3.zero;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            bikeRigidbody.velocity = Vector3.zero;
        }
        if (Input.GetKeyDown(KeyCode.Space) && boostSlider.value == 1f)
        {
            Boost();            
        }        
        animCarretera.SetBool("CarreteraMove", true);
        animCiudad.SetBool("CiudadMove", true);
        animMountain.SetBool("BikeAni", true);
    }

    void FixedUpdate()
    {
        bikeRigidbody.velocity = new Vector3(moveSpeed, bikeRigidbody.velocity.y, Time.deltaTime * moveSpeed);        
    }
    
    public void Boost()
    {
        if (boostCoroutine != null)
        {
            StopCoroutine(boostCoroutine);            
        }
        boostCoroutine = StartCoroutine(BoostForDuration(boostDuration));
        animCarretera.SetBool("CarreteraBoost", true);
        animCiudad.SetBool("CiudadBoost", true);
        animMountain.SetBool("Boost", true);
        audioSource.PlayOneShot(audioBoost);
    }

    private IEnumerator BoostForDuration(float duration)
    {
        float initialSpeed = moveSpeed;
        moveSpeed = boostSpeed;
        float timer = 0;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            boostSlider.value = 1f - (timer / duration);
            yield return null;
        }
        moveSpeed = initialSpeed;
        boostSlider.value = 0f;
        boostCoroutine = null;
        animCarretera.SetBool("CarreteraBoost", false);
        animCiudad.SetBool("CiudadBoost", false);
        animMountain.SetBool("Boost", false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(BoostObjectTag)) 
        {
            boostSlider.value += boostFillAmount;
            if (boostSlider.value >= 1f)
            {
                boostSlider.value = 1f;
            }
        }
        if (collision.CompareTag("Enenemy"))
        {
            audioSource.PlayOneShot(audioGolpe);
            EmitDustParticle();
        }
    }
    private void EmitDustParticle()
    {
        Vector2 particlePosition = new Vector2(transform.position.x + 0f, transform.position.y + 0f);
        GameObject dustParticles = Instantiate(crashParticlePrefab, particlePosition, Quaternion.identity, null);
        float destroyTime = Time.realtimeSinceStartup + 5f;
        StartCoroutine(DestroyAfterTime(dustParticles, destroyTime));
    }

    private IEnumerator DestroyAfterTime(GameObject obj, float time)
    {
        while (Time.realtimeSinceStartup < time)
        {
            yield return null;
        }
        Destroy(obj);
    }
    public void MoveUp()
    {
        bikeRigidbody.velocity = Vector3.down * -moveUpDown;
    }

    public void MoveDown()
    {
        bikeRigidbody.velocity = Vector3.up * -moveUpDown;
    }

    public void StopMoving()
    {
        bikeRigidbody.velocity = Vector3.zero * -moveUpDown;
    }
}





//using System.Collections;
//using UnityEngine;
//using UnityEngine.UI;

//public class BikeControllerKeyboard : MonoBehaviour
//{
//    public float moveUpDown;
//    private Rigidbody2D bikeRigidbody;
//    public float moveSpeed;
//    public float boostSpeed;
//    public float boostDuration;
//    private Coroutine boostCoroutine;
//    public Slider boostSlider;
//    public float boostFillAmount;

//    void Start()
//    {
//        bikeRigidbody = GetComponent<Rigidbody2D>();
//    }

//    void Update()
//    {
//        if (Input.GetKey(KeyCode.W))
//        {
//            transform.Translate(Vector2.up * moveUpDown * Time.deltaTime);
//        }
//        if (Input.GetKey(KeyCode.S))
//        {
//            transform.Translate(Vector2.down * moveUpDown * Time.deltaTime);
//        }
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            if (BoostManager.Instance.boostObject.activeSelf)
//            {
//                Boost();
//                BoostManager.Instance.boostObject.SetActive(false);
//            }
//        }

//        Vector3 vector3 = transform.position;
//        vector3.z = vector3.y;
//        transform.position = vector3;
//    }

//    void FixedUpdate()
//    {
//        bikeRigidbody.velocity = new Vector3(moveSpeed, bikeRigidbody.velocity.y, Time.deltaTime * moveSpeed);
//    }

//    public void Boost()
//    {
//        if (boostCoroutine != null)
//        {
//            StopCoroutine(boostCoroutine);
//        }
//        boostCoroutine = StartCoroutine(BoostForDuration(boostDuration));
//    }

//    private IEnumerator BoostForDuration(float duration)
//    {
//        float initialSpeed = moveSpeed;
//        moveSpeed = boostSpeed;
//        float timer = 0;
//        while (timer < duration)
//        {
//            timer += Time.deltaTime;
//            boostSlider.value = 1f - (timer / duration);
//            yield return null;
//        }
//        moveSpeed = initialSpeed;
//        boostSlider.value = 1f;
//        BoostManager.Instance.boostObject.SetActive(false);
//    }

//    public void MoveUp()
//    {
//        bikeRigidbody.velocity = Vector2.up * moveSpeed;
//    }

//    public void MoveDown()
//    {
//        bikeRigidbody.velocity = Vector2.up * -moveSpeed;
//    }

//    public void StopMoving()
//    {
//        bikeRigidbody.velocity = Vector2.zero;
//    }

//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.gameObject == BoostManager.Instance.boostObject)
//        {
//            if (BoostManager.Instance.boostObject != null)
//            {
//                boostSlider.value += boostFillAmount;
//                if (boostSlider.value >= 1f)
//                {
//                    boostSlider.value = 1f;
//                    BoostManager.Instance.boostObject.SetActive(false);
//                }
//                Destroy(other.gameObject);
//                BoostManager.Instance.boostObject = null;
//            }
//        }
//    }
//}
