using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpGoldUIPresenter : MonoBehaviour
{
    [SerializeField] 
    Slider slider;
    InGameWallet wallet;

    float imageCorrectValue = 0.28F;

    void Start()
    {
        wallet = this.GetComponent<InGameWallet>();
    }


    // Update is called once per frame
    void Update()
    {
        float _rate = wallet.GetRateOfNextLevel();
        slider.value = _rate + imageCorrectValue;
    }
}
