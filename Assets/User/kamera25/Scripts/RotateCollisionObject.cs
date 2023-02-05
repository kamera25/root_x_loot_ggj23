using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using System;

public class RotateCollisionObject : MonoBehaviour
{
    enum InputMode
    {
        NORMAL,
        INVERSE
    }

    UsingInputType inputType;
    private Vector2 _moveInputValue;
    private Transform thisTrans;

    private Quaternion nowDirection;

    [SerializeField]
    private InputMode inputMode = InputMode.NORMAL;

    // Start is called before the first frame update
    void Start()
    {
        thisTrans = this.transform;
        nowDirection = Quaternion.Euler(0, 0.0f, 0);

        inputType = GameObject.FindWithTag("GameController").GetComponent<UsingInputType>();
    }

    // Update is called once per frame
    void Update()
    {
        if( inputType.Controller ==  UsingInputType.InputType.KEYBOARD )
        {
            OnMoveByKeyboard();
        }
        else // TBD : can only use 8bitDo Pro.
        {
            OnMoveBy8bitDo(); 
        }
    }

    private void OnMoveBy8bitDo()
    {
        var _joypad = Joystick.all.FirstOrDefault();
        if( _joypad == null)
        {
            throw new System.Exception("MoveController : 8bitDo Proの接続がありません。接続を確認してください。");
        }


        _moveInputValue.x = (float) _joypad["Rx"].ReadValueAsObject();
        _moveInputValue.y = (float) _joypad["Ry"].ReadValueAsObject();

        if( inputMode == InputMode.INVERSE)
        {
            _moveInputValue *= -1;
        }


        if (_moveInputValue.x < -0.1F && _moveInputValue.y < -0.1f)
        {
            nowDirection = Quaternion.Euler(0, 135.0f, 0);
        }
        else if (_moveInputValue.x < -0.1f && _moveInputValue.y > 0.1f)
        {
            nowDirection = Quaternion.Euler(0, 225.0f, 0);
        }
        else if (_moveInputValue.x > 0.1f && _moveInputValue.y > 0.1f)
        {
            nowDirection = Quaternion.Euler(0, -45.0f, 0);
        }
        else if (_moveInputValue.x > 0.1f && _moveInputValue.y < -0.1f)
        {
            nowDirection = Quaternion.Euler(0, 45.0f, 0);
        }
        else if(_moveInputValue.x < -0.1f)
        {
            nowDirection = Quaternion.Euler(0, 180.0f, 0);
        }
        else if (_moveInputValue.x > 0.1f)
        {
            nowDirection = Quaternion.Euler(0, 0.0f, 0);
        }
        else if (_moveInputValue.y < -0.1f)
        {
            nowDirection = Quaternion.Euler(0, 90.0f, 0);
        }
        else if (_moveInputValue.y > 0.1f)
        {
            nowDirection = Quaternion.Euler(0, -90.0f, 0);
        }

        thisTrans.rotation = nowDirection;
    }

    private void OnMoveByKeyboard()
    {

        _moveInputValue.x = 0F;
        _moveInputValue.y = 0F;

        var _keyboard = Keyboard.current;

        _moveInputValue.y += _keyboard.wKey.isPressed ? 1F: 0F;
        _moveInputValue.y += _keyboard.sKey.isPressed ? -1F: 0F;
        _moveInputValue.x += _keyboard.dKey.isPressed ? 1F: 0F;
        _moveInputValue.x += _keyboard.aKey.isPressed ? -1F: 0F;

        if (_moveInputValue.x == -1F && _moveInputValue.y == -1f)
        {
            nowDirection = Quaternion.Euler(0, 135.0f, 0);
        }
        else if (_moveInputValue.x == -1f && _moveInputValue.y == 1f)
        {
            nowDirection = Quaternion.Euler(0, 225.0f, 0);
        }
        else if (_moveInputValue.x == 1f && _moveInputValue.y == 1f)
        {
            nowDirection = Quaternion.Euler(0, -45.0f, 0);
        }
        else if (_moveInputValue.x == 1f && _moveInputValue.y == -1f)
        {
            nowDirection = Quaternion.Euler(0, 45.0f, 0);
        }
        else if(_moveInputValue.x == -1f)
        {
            nowDirection = Quaternion.Euler(0, 180.0f, 0);
        }
        else if (_moveInputValue.x == 1f)
        {
            nowDirection = Quaternion.Euler(0, 0.0f, 0);
        }
        else if (_moveInputValue.y == -1f)
        {
            nowDirection = Quaternion.Euler(0, 90.0f, 0);
        }
        else if (_moveInputValue.y == 1f)
        {
            nowDirection = Quaternion.Euler(0, -90.0f, 0);
        }

        thisTrans.rotation = nowDirection;
    }
}
