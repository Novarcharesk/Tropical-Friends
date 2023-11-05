using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float dayDuration = 720f; // Duration of a full day in seconds (12 minutes)
    public Color dayColor;
    public Color nightColor;
    public Color dawnColor;
    public Color sunsetColor;
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

        // Check for specific hours and print debug messages
        int currentHour = Mathf.FloorToInt(currentTime / 3600) % 24;
        if (currentHour == 5)
        {
            Debug.Log("It's 5:00 AM. Transitioning to dawn.");
        }
        else if (currentHour == 17)
        {
            Debug.Log("It's 5:00 PM. Transitioning to sunset.");
        }

        // Update lighting based on the time of day
        if (isDaytime)
        {
            // Transition to daytime lighting
            SetLighting(dayColor);
        }
        else
        {
            // Transition to nighttime lighting
            SetLighting(nightColor);
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

    private void SetLighting(Color lightColor)
    {
        // Use Mathf.Lerp or other methods to smoothly transition lighting color
        directionalLight.color = Color.Lerp(directionalLight.color, lightColor, Time.deltaTime);
    }
}