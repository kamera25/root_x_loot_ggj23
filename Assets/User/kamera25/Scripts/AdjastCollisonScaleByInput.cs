using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class AdjastCollisonScaleByInput : MonoBehaviour
{
    AdjastCollisionByLevel collisionLevel;
    private Vector2 _moveInputValue;
    UsingInputType inputType;

    bool isSuked = false;

    // Start is called before the first frame update
    void Start()
    {
        inputType = GameObject.FindWithTag("GameController").GetComponent<UsingInputType>();
        collisionLevel = this.GetComponent<AdjastCollisionByLevel>();

    }

    // Update is called once per frame
    void Update()
    {
        if( inputType.Controller == UsingInputType.InputType.KEYBOARD )
        {
            SetCollisionScaleByKeyboard();
        }
        else
        {
            SetCollisionScaleByJoyPad();
        }

    }

    void SetCollisionScaleByJoyPad()
    {
        var _joypad = Joystick.all.FirstOrDefault();
        if( _joypad == null)
        {
            throw new System.Exception("MoveController : 8bitDo Proの接続がありません。接続を確認してください。");
        }

        _moveInputValue.x = (float) _joypad["Rx"].ReadValueAsObject();
        _moveInputValue.y = (float) _joypad["Ry"].ReadValueAsObject();


        float _magnitude = _moveInputValue.magnitude;
        Transform _collision = collisionLevel.GetNowCollisionGameObject().transform;
        if( _magnitude < 0.2F )
        {
            _collision.localScale = Vector3.zero;
            isSuked = false;
            return;
        }

        Vector3 _scale = Vector3.one;
        _scale.z = _magnitude;
        _collision.localScale = _scale;

        isSuked = true;
    }

    void SetCollisionScaleByKeyboard()
    {
        var _keyboard = Keyboard.current;
        if( _keyboard == null)
        {
            throw new System.Exception("MoveController : 8bitDo Proの接続がありません。接続を確認してください。");
        }

        _moveInputValue.y = _keyboard.wKey.isPressed || _keyboard.sKey.isPressed ? 1F: 0F;
        _moveInputValue.x = _keyboard.dKey.isPressed || _keyboard.aKey.isPressed ? 1F: 0F;

        float _magnitude = _moveInputValue.magnitude;
        Transform _collision = collisionLevel.GetNowCollisionGameObject().transform;
        if( _magnitude < 0.2F )
        {
            _collision.localScale = Vector3.zero;
            isSuked = false;
            return;
        }

        Vector3 _scale = Vector3.one;
        _scale.z = _magnitude;
        _collision.localScale = _scale;

        isSuked = true;
    }

    public bool IsSuked()
    {
        return isSuked;
    }
}
