using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float dayDuration = 720f; // Duration of a full day in seconds (12 minutes)
    public Color dayLightColor;
    public float dayLightIntensity;
    public Color nightLightColor;
    public float nightLightIntensity;
    public Light directionalLight; // Reference to your directional light

    private float currentTime = 0f; // Start time at 3:00 PM

    private void Start()
    {
        // Initialize the time to the start of the day
        currentTime = 3 * 60 * 60; // 3:00 PM
    }

    private void Update()
    {
        // Update the in-game time every half second
        currentTime += Time.deltaTime * 2;

        // Determine if it's day or night based on currentTime
        bool isDaytime = IsDaytime(currentTime);

        // Update lighting based on the time of day
        if (isDaytime)
        {
            // Transition to daytime lighting
            SetLighting(dayLightColor, dayLightIntensity);
        }
        else
        {
            // Transition to nighttime lighting
            SetLighting(nightLightColor, nightLightIntensity);
        }
    }

    private bool IsDaytime(float time)
    {
        // Determine if it's day or night based on the current time
        int hour = Mathf.FloorToInt(time / 3600) % 24; // Calculate the current hour

        // Define the time intervals for lighting transitions
        int sunsetStart = 17; // 5:00 PM
        int nightStart = 18;  // 6:00 PM
        int sunriseStart = 5; // 5:00 AM
        int dayStart = 6;     // 6:00 AM

        return (hour >= sunriseStart && hour < sunsetStart) || (hour >= sunriseStart && hour < nightStart);
    }

    private void SetLighting(Color lightColor, float lightIntensity)
    {
        // Use Mathf.Lerp or other methods to smoothly transition lighting properties
        directionalLight.color = Color.Lerp(directionalLight.color, lightColor, Time.deltaTime);
        directionalLight.intensity = Mathf.Lerp(directionalLight.intensity, lightIntensity, Time.deltaTime);
    }
}