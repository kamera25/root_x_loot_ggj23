using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SukeFurnitureBehavior : MonoBehaviour
{
    FurnitureProperty property;
    Transform playerPurseTrans;
    Transform thisTrans;

    [SerializeField]
    GameObject pointTextObject;

    private int maxSukeTime;
    private int sukeTime;
    private InGameWallet wallet;
    bool isSuked = false;

    const float getDistance = 0.2F;
    const float levelThreshold = 100F;

    // Start is called before the first frame update
    void Start()
    {
        property = this.GetComponent<FurnitureProperty>();
        playerPurseTrans = GameObject.FindWithTag("PursePivot").transform;
        wallet = GameObject.FindWithTag("GameController").GetComponent<InGameWallet>();
        thisTrans = this.transform;

        maxSukeTime = property.Weight;
        sukeTime = maxSukeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if( !isSuked )
        {
            return;
        }

        SukeMove();
    }

    void SukedItemEvent()
    {
        wallet.AddMoney(property.Worth);
        Destroy(this.gameObject);
        GameObject _pointObj = Instantiate( pointTextObject, thisTrans.position, Quaternion.Euler( new Vector3( 0F, -90F, 0F)) );
        
        if( string.IsNullOrEmpty(property.ItemSukedMessage) )
        {
            _pointObj.GetComponent<PointTextBehavior>().UpdatePointText( property.Worth );
        }
        else
        {
            _pointObj.GetComponent<PointTextBehavior>().UpdatePointText( property.ItemSukedMessage );
        }
    }

    void OnTriggerStay(Collider other)
    {
        GameObject _col = other.gameObject;
        if( !_col.CompareTag("SuctionCollision"))
        {
            return;
        }

        sukeTime -= (int) GetSuctionPowerByCurve();
        if(sukeTime < 0F)
        {
            isSuked = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        GameObject _col = other.gameObject;
        if( !_col.CompareTag("SuctionCollision"))
        {
            return;
        }

        sukeTime =  maxSukeTime;
    }

    void SukeMove()
    {
        Vector3 _moveDirection =  (playerPurseTrans.position - thisTrans.position).normalized;
        _moveDirection.y = 0;

        thisTrans.Translate( _moveDirection * 4.5F * Time.deltaTime, Space.World);
        //this.transform.Translate( _moveDirection * 0.04F);

        float _distance = _moveDirection.sqrMagnitude;
        if( _distance < getDistance)
        {
            SukedItemEvent();
        }
    }

    public float GetSuctionPowerByCurve()
    {
        float levelDifference = property.Weight / levelThreshold - wallet.PlayerLevel;
        float clampLevelDifference = Mathf.Clamp( levelDifference, 0F, float.MaxValue);

        return ( wallet.WeightAdjustment.Evaluate( clampLevelDifference ));
    }

    public bool IsHitCollision()
    {
        return sukeTime < maxSukeTime;
    }

    public bool IsSuked()
    {
        return sukeTime < 0F;
    }
}
