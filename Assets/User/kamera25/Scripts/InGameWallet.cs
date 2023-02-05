using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameWallet : MonoBehaviour
{
    int gold = 0;
    public int Gold => gold;

    int playerLevel = 1;
    public int PlayerLevel => playerLevel;

    public List<int> levelUpConditionGoldList = new List<int>();

    [SerializeField]
    AnimationCurve weightAdjustment;
    public AnimationCurve WeightAdjustment => weightAdjustment;


    public void AddMoney( int money)
    {
        gold += money;
        CheckLevelByMoney();
    }

    public float GetRateOfNextLevel()
    {
        float _nowLevelNeedMoney = playerLevel == 1 ? 0F : levelUpConditionGoldList[playerLevel - 2];

        float _nowGetMoneyRate = 1F; 
        try
        {
            float _nextLevelUpNeedMoney = levelUpConditionGoldList[playerLevel] - _nowLevelNeedMoney;
            _nowGetMoneyRate = (gold - _nowLevelNeedMoney) / _nextLevelUpNeedMoney;
        }
        catch
        {
            Debug.LogError("InGameWallet : レベルの最大値に達しました。GetRateOfNextLevelは常に1Fを戻り値として返します。");
        }


        return _nowGetMoneyRate;
    }

    private void CheckLevelByMoney()
    {
        int i = 2;
        foreach( int levelCondition in levelUpConditionGoldList)
        {
            if( levelCondition < gold)
            {
                playerLevel = i;
            }
            i++;
        }
    }
}
