using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureProperty : MonoBehaviour
{
    [SerializeField]
    int weight = 100;
    public int Weight => weight;

    [SerializeField]
    int worth = 100;
    public int Worth => worth;

    [SerializeField]
    string itemSukedMessage;
    public string ItemSukedMessage => itemSukedMessage;

    int GetGold()
    {
        return worth;
    }
}
