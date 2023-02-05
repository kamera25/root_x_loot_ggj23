using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;


public class MoveController : MonoBehaviour
{
    [SerializeField] private AdjastCollisonScaleByInput collisionData;
    [SerializeField] private float _moveForce = 50;

    [SerializeField] private GameObject CatchObject;

    [SerializeField] private int PlayerNo = 1;

    private GameObject myPlayerModel;


//    private Bob_InputAction _bobInput;

    private Rigidbody _rigidbody;
    private Vector2 _moveInputValue;
    public Vector2 MoveInputValue => _moveInputValue;


    InputAction moveAction;
    InputAction fireAction;

    UsingInputType inputType;


    private void Awake()
    {
        myPlayerModel = this.gameObject;
        _rigidbody = this.GetComponent<Rigidbody>();
        inputType = GameObject.FindWithTag("GameController").GetComponent<UsingInputType>();
    }

    private void Update()
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
        // Move設定

        var _joypad = Joystick.all.FirstOrDefault();
        if( _joypad == null)
        {
            throw new System.Exception("MoveController : 8bitDo Proの接続がありません。接続を確認してください。");
        }

         _moveInputValue = _joypad.stick.ReadValue();

        if( collisionData.IsSuked() )
        {       
            Vector3 _direction = new Vector3 ( -(float) _joypad["Rx"].ReadValueAsObject(), -(float) _joypad["Ry"].ReadValueAsObject() );
            myPlayerModel.transform.rotation = GetMoveDirection( _direction, 0.1F, 0.5F ); 
        }
        else
        {
            myPlayerModel.transform.rotation = GetMoveDirection( _moveInputValue, 0.1F, 0.5F ); 
        }

    }

    private void OnMoveByKeyboard()
    {
        // Move設定
        _moveInputValue.x = 0F;
        _moveInputValue.y = 0F;

        var _keyboard = Keyboard.current;

        _moveInputValue.y += _keyboard.upArrowKey.isPressed ? 1F: 0F;
        _moveInputValue.y += _keyboard.downArrowKey.isPressed ? -1F: 0F;
        _moveInputValue.x += _keyboard.rightArrowKey.isPressed ? 1F: 0F;
        _moveInputValue.x += _keyboard.leftArrowKey.isPressed ? -1F: 0F;

        if( collisionData.IsSuked() )
        {       
            Vector2 _direction = new Vector2();
            _direction.y += _keyboard.wKey.isPressed ? -1F: 0F;
            _direction.y += _keyboard.sKey.isPressed ? 1F: 0F;
            _direction.x += _keyboard.dKey.isPressed ? -1F: 0F;
            _direction.x += _keyboard.aKey.isPressed ? 1F: 0F;
            myPlayerModel.transform.rotation = GetMoveDirection( -_direction, 0.1F, 0.5F ); 
        }
        else
        {
            myPlayerModel.transform.rotation = GetMoveDirection( _moveInputValue, 0.1F, 0.7F);
        }
        
    }

    Quaternion GetMoveDirection( Vector2 _moveInputValue, float minimumThreshold, float minimumThresholdDiagonally )
    {
        if (_moveInputValue.x < -minimumThresholdDiagonally && _moveInputValue.y < -minimumThresholdDiagonally )
        {
            return Quaternion.Euler(0, 135.0f, 0);
        }
        else if (_moveInputValue.x < -minimumThresholdDiagonally && _moveInputValue.y > minimumThresholdDiagonally )
        {
            return Quaternion.Euler(0, 225.0f, 0);
        }
        else if (_moveInputValue.x > minimumThresholdDiagonally && _moveInputValue.y > minimumThresholdDiagonally )
        {
            return Quaternion.Euler(0, -45.0f, 0);
        }
        else if (_moveInputValue.x > minimumThresholdDiagonally && _moveInputValue.y < -minimumThresholdDiagonally )
        {
            return Quaternion.Euler(0, 45.0f, 0);
        }
        else if(_moveInputValue.x > minimumThreshold)
        {
            return Quaternion.Euler(0, 0.0f, 0);
        }
        else if (_moveInputValue.x < -minimumThreshold)
        {
            return Quaternion.Euler(0, 180.0f, 0);
        }
        else if (_moveInputValue.y < -minimumThreshold)
        {
            return Quaternion.Euler(0, 90.0f, 0);
        }
        else if (_moveInputValue.y > minimumThreshold)
        {
            return Quaternion.Euler(0, -90.0f, 0);
        }

        return myPlayerModel.transform.rotation;
    }

    private void FixedUpdate()
    {
        //移動方向へ力を掛ける
        _rigidbody.AddForce(new Vector3(
            _moveInputValue.y * -1, 0, _moveInputValue.x ) * _moveForce);
    }

    public int GetPlayerNo()
    {
        return PlayerNo;
    }

/*

    public void SetupInputActionByKeyboard( PlayerInput playerInput)
    {
        string _NumberStr = playerID == 1 ?  "Primary" : "Secondary";

        string moveActionString = "Move_" + _NumberStr;
        moveAction = playerInput.actions[moveActionString];

        string fireActionString = "Fire_" + _NumberStr;
        fireAction = playerInput.actions[fireActionString];


        moveAction.started += OnMove;
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;

        fireAction.started += OnHoldStart;
        fireAction.canceled += OnFire;   
    }*/

/*
    public void SetupInputActionByGamepad( PlayerInput playerInput)
    {
        string moveActionString = "Move_Primary";
        moveAction = playerInput.actions[moveActionString];

        string fireActionString = "Fire_Primary";
        fireAction = playerInput.actions[fireActionString];


        moveAction.started += OnMove;
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;

        fireAction.started += OnHoldStart;
        fireAction.canceled += OnFire;   
    }
*/
}
