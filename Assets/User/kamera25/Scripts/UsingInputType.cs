using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingInputType : MonoBehaviour
{
    [SerializeField]
    InputType controllerType = InputType.KEYBOARD;
    public InputType Controller => controllerType;

    public enum InputType
    {
        KEYBOARD,
        JOYPAD
    }
}
