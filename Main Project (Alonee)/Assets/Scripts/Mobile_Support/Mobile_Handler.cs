using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Mobile_Handler : MonoBehaviour
{
    public FixedJoystick moveJoystick;
    public FixedTouchField touchField;
    public FixedButton jumpButton;


   // public MouseLook mouseLook;

    private void Update()
    {
        var fps = GetComponent<RigidbodyFirstPersonController>();
        fps.runAxis = moveJoystick.Direction;
        fps.jumpAxis = jumpButton.Pressed;
        fps.mouseLook.lookAxis = touchField.TouchDist;
    }
}
