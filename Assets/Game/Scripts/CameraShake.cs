using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeIntensity = 0.1f;

    public void ShakeCamera()
    {
        StartCoroutine(ShakeAnimation());
    }

    private IEnumerator ShakeAnimation()
    {
        float shakeDuration = 0.2f;
        float shakeEndTime = Time.time + shakeDuration;
        Vector3 originalPos = transform.position;

        while (Time.time < shakeEndTime)
        {
            float x = originalPos.x + Random.Range(-1f, 1f) * shakeIntensity;
            float y = originalPos.y + Random.Range(-1f, 1f) * shakeIntensity;

            transform.position = new Vector3(x, y, originalPos.z);

            yield return null;
        }

        transform.position = originalPos;
    }
}
