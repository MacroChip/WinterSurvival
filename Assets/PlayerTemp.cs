using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class PlayerTemp : MonoBehaviour
{
    public float startingTemp = 100;                            // The temperature the player starts the game with.
    public float currentTemp;                                   // The current temperature the player has.
    public Slider tempGauge;                                    // Reference to the UI's temperature bar.
    public Image coldImage;                                     // Reference to an image to constrict vision as temperature decreases.

    AudioSource playerAudio;                                    // Reference to the AudioSource component.
    bool isFrozen;                                              // Whether the player is frozen.
    bool temperatureChanged;
    private const float WARMING_TEMPERATURE = 0.5f;

    void Start()
    {
        NewDay();
        InvokeRepeating("ChangeTemp", 10, 10);
    }

    void NewDay()
    {
        playerAudio = GetComponent<AudioSource>();
        currentTemp = startingTemp;
    }

    void RegainConsciousness()
    {
        currentTemp = 97;
    }

    void Update()
    {
        Sprite sprite = null;
        if (temperatureChanged && currentTemp >= 98)
        {
            Debug.Log("nulling out vision constriction sprite");
            coldImage.sprite = null;
            coldImage.color = new Color(255, 255, 255, 0);
        }
        if (temperatureChanged && currentTemp < 98 &&  currentTemp > 97.66f)
        {
            sprite = Resources.Load<Sprite>("VisionStages/Stage1");
        }
        else if (temperatureChanged && currentTemp < 97.67 && currentTemp > 97.33f)
        {
            sprite = Resources.Load<Sprite>("VisionStages/Stage2");
        }
        else if (temperatureChanged && currentTemp < 97.67 && currentTemp > 97.33f)
        {
            sprite = Resources.Load<Sprite>("VisionStages/Stage3");
        }
        else if (temperatureChanged && currentTemp < 97.34 && currentTemp > 97)
        {
            sprite = Resources.Load<Sprite>("VisionStages/Stage4");
        }
        else if (temperatureChanged && currentTemp < 97 && currentTemp > 96.66f)
        {
            sprite = Resources.Load<Sprite>("VisionStages/Stage5");
        }
        else if (temperatureChanged && currentTemp < 96.67f && currentTemp > 96.33f)
        {
            sprite = Resources.Load<Sprite>("VisionStages/Stage6");
        }
        else if (temperatureChanged && currentTemp < 96.34f && currentTemp > 96)
        {
            sprite = Resources.Load<Sprite>("VisionStages/Stage7");
        }
        else if (temperatureChanged && currentTemp < 96 && currentTemp > 95.66f)
        {
            sprite = Resources.Load<Sprite>("VisionStages/Stage8");
        }
        else if (temperatureChanged && currentTemp < 95.67f && currentTemp > 95)
        {
            sprite = Resources.Load<Sprite>("VisionStages/Stage9");
        }
        if (sprite)
        {
            Debug.Log("setting vision constriction sprite to " + sprite.name);
            coldImage.sprite = sprite;
            coldImage.color = new Color(255, 255, 255, 255);
        }
        temperatureChanged = false;
    }

    public void ChangeTemp()
    {
        if (GetComponent<OnEnterHouse>().IsInHouse())
        {
            currentTemp = System.Math.Min(startingTemp, currentTemp + WARMING_TEMPERATURE);
            tempGauge.value = currentTemp;
        } else
        {
            float airTemp = .083f;

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
        temperatureChanged = true;
    }


    void Freeze()
    {
        // Set the frozen flag so this function won't be called again.
        isFrozen = true;

        // Set the audiosource to play the frozen clip and play it (this will stop the cold sound from playing).
        //playerAudio.Play();
    }
}