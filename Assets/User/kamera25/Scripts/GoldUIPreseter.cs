using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldUIPreseter : MonoBehaviour
{
    [SerializeField]
    TMPro.TMP_Text goldText;
    InGameWallet wallet;
    
    void Start()
    {
        wallet = this.GetComponent<InGameWallet>();
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = wallet.Gold.ToString() + "G";
    }
}
