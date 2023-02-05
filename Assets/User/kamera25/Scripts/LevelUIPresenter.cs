using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIPresenter : MonoBehaviour
{
    [SerializeField]
    TMPro.TMP_Text levelText;
    InGameWallet level;
    
    void Start()
    {
        level = this.GetComponent<InGameWallet>();
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Level : " + level.PlayerLevel.ToString();
    }
}
