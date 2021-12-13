using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public AudioClip soundOn;
    public AudioClip soundOff;

    private Light light;
    private AudioSource audio;
    private MagicLightSource revealScript;

    private void Start()
    {
        light = gameObject.GetComponent<Light>();
        audio = gameObject.GetComponent<AudioSource>();
        revealScript = gameObject.GetComponent<MagicLightSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (light.enabled == false)
            {
                light.enabled = true;
                audio.clip = soundOn;
                audio.Play();
                revealScript.enabled = true;
            }
            else
            {
                light.enabled = false;
                audio.clip = soundOff;
                audio.Play();
                revealScript.enabled = false;
            }
        }
    }
}
