using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputController
{
    //button names
    private static string _nameButtonA = "XboxA_Button";
    private static string _nameButtonB = "XboxB_Button";
    private static string _nameButtonX = "XboxX_Button";
    private static string _nameButtonY = "XboxY_Button";

    // axis input
    public static Vector3 GetLeftJoystick()
    {
        float h = Input.GetAxis("Xbox_Horizontal_Left_Joystick");
        float v = Input.GetAxis("Xbox_Vertical_Left_Joystick");

        Vector3 input = new Vector3(h, 0, v);

        return input;
    }

    public static Vector3 GetRightJoystick()
    {
        float v = Input.GetAxis("Xbox_Vertical_Right_Joystick");

        Vector3 input = new Vector3(0, 0, v);

        return input;
    }

    public static float GetRightTrigger()
    {
        return Input.GetAxis("Xbox_Right_Trigger"); 
    }

    public static float GetLeftTrigger()
    {
        return Input.GetAxis("Xbox_Left_Trigger");
    }

    // button input

    public static bool IsButtonAPressed()
    {
        return Input.GetButtonDown(_nameButtonA); 
    }

    public static bool IsButtonBPressed()
    {
        return Input.GetButtonDown(_nameButtonB);
    }

    public static bool IsButtonXPressed()
    {
        return Input.GetButtonDown(_nameButtonX);
    }

    public static bool IsButtonYPressed()
    {
        return Input.GetButtonDown(_nameButtonY);
    }

    public static bool IsStartButtonPressed()
    {
        return Input.GetButtonDown("Xbox_Start_Button");
    }

    public static bool IsSelectButtonPressed()
    {
        return Input.GetButtonDown("Xbox_Select_Button");
    }
}
