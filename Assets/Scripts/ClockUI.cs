using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockUI : MonoBehaviour
{
    public ToD_Base dayNightCycle; // Reference to the ToD_Base script
    public Transform clockHand; // Reference to the Transform of the clock hand

    void Update()
    {
        // Ensure the dayNightCycle reference is not null
        if (dayNightCycle != null)
        {
            // Calculate the rotation angle based on the current time
            float rotationAngle = dayNightCycle.Get_fCurrentHour * 360.0f / 24.0f;

            // Update the clock hand's rotation while maintaining the initial offset
            clockHand.localRotation = Quaternion.Euler(0, 0, rotationAngle - 90); // -90 to offset the initial position
        }
    }
}