using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    [Header("General Setup Settings")]
    [Tooltip("How fast ship moves up and down based upon player input.")] 
    [SerializeField] float controlSpeed = 10f;
    [Tooltip("The left/right range of how far the ship can fly.")]
    [SerializeField] float xRange = 10f;
    [Tooltip("The up/down range of how far the ship can fly.")]
    [SerializeField] float yRange = 15f;
    [Tooltip("This is the array containing the two lasers. Shouldn't necessarily be more.")]
    [SerializeField] GameObject[] lasers;

    [Header("Screen position based tuning.")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = -5f;

    [Header("Player input based tuning.")]
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlRollFactor = 5f;

    float xThrow, yThrow;


    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor; 

        float pitch =  pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor; 
        float roll = xThrow * controlRollFactor; 
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");

        yThrow = Input.GetAxis("Vertical");
       
        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Jump"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }

     void SetLasersActive(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }



}
