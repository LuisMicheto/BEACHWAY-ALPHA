using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimedImmunity : MonoBehaviour
{
    public float immunityDuration = 5f;
    private float immunityTimer = 0f;
    private bool isImmune = false;
    public Button immunityButton;

    private void Start()
    {
        immunityButton.onClick.AddListener(ActivateImmunity);
    }

    private void Update()
    {
        if (isImmune)
        {
            immunityTimer += Time.deltaTime;
            if (immunityTimer >= immunityDuration)
            {
                isImmune = false;
                immunityTimer = 0f;
            }
        }
    }

    public void ActivateImmunity()
    {
        isImmune = true;
    }
}