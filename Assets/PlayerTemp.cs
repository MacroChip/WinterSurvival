using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class PlayerTemp : MonoBehaviour
{
    public float startingTemp = 100;                            // The temperature the player starts the game with.
    public float currentTemp;                                   // The current temperature the player has.
    public Slider tempGauge;                                    // Reference to the UI's temperature bar.
    public Image coldImage;                                     // Reference to an image to constrict vision as temperature decreases.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(0f, 0f, 1f, 0.1f);     // The color the damageImage is set to, to flash.

    public Image visionState; 


    AudioSource playerAudio;                                    // Reference to the AudioSource component.
    bool isFrozen;                                              // Whether the player is frozen.
    bool colder;                                                // True when the player gets colder.

    void Start()
    {
        NewDay();
        InvokeRepeating("LowerTemp", 10, 10);
    }

    void NewDay()
    {
        // Setting up the references.
        playerAudio = GetComponent<AudioSource>();
        // Set the initial health of the player.
        currentTemp = startingTemp;
    }

    void RegainConsciousness()
    {
        currentTemp = 97;
    }

    void Update()
    {
        Sprite sprite = null;
        //If the player is outside...
        if (colder && currentTemp < 98 &&  currentTemp > 97.66f)
        {
            sprite = Resources.Load<Sprite>("VisionStages/Stage1");
        }
        else if (colder && currentTemp < 97.67 && currentTemp > 97.33f)
        {
            sprite = Resources.Load<Sprite>("VisionStages/Stage2");
        }
        else if (colder && currentTemp < 97.67 && currentTemp > 97.33f)
        {
            sprite = Resources.Load<Sprite>("VisionStages/Stage3");
        }
        else if (colder && currentTemp < 97.34 && currentTemp > 97)
        {
            sprite = Resources.Load<Sprite>("VisionStages/Stage4");
        }
        else if (colder && currentTemp < 97 && currentTemp > 96.66f)
        {
            sprite = Resources.Load<Sprite>("VisionStages/Stage5");
        }
        else if (colder && currentTemp < 96.67f && currentTemp > 96.33f)
        {
            sprite = Resources.Load<Sprite>("VisionStages/Stage6");
        }
        else if (colder && currentTemp < 96.34f && currentTemp > 96)
        {
            sprite = Resources.Load<Sprite>("VisionStages/Stage7");
        }
        else if (colder && currentTemp < 96 && currentTemp > 95.66f)
        {
            sprite = Resources.Load<Sprite>("VisionStages/Stage8");
        }
        else if (colder && currentTemp < 95.67f && currentTemp > 95)
        {
            sprite = Resources.Load<Sprite>("VisionStages/Stage9");
        }
        // Reset the colder flag.
        coldImage.sprite = sprite;
        colder = false;
    }

    public void LowerTemp()
    {
        if (!GetComponent<OnEnterHouse>().IsInHouse())
        {
            float airTemp = .083f;

            colder = true;

            currentTemp -= airTemp;

            // Set the temp bar's value to the current temp.
            tempGauge.value = currentTemp;

            // Play the ice sound effect.
            //playerAudio.Play();

            // If the player has frozen and the frozen flag hasn't been set yet...
            if (currentTemp <= 95 && !isFrozen)
            {
                // ... it should freeze.
                Freeze();
            }
        }
    }


    void Freeze()
    {
        // Set the frozen flag so this function won't be called again.
        isFrozen = true;

        // Set the audiosource to play the frozen clip and play it (this will stop the cold sound from playing).
        //playerAudio.Play();
    }
}