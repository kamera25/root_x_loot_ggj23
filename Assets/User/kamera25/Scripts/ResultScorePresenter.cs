using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultScorePresenter : MonoBehaviour
{
    private int resultScore = 0;
    [SerializeField] private TextMeshProUGUI scoretextUI;

    public void SetResultScore( int _score )
    {
        resultScore = _score;
        scoretextUI.text = "Gold : " + _score.ToString();
    }
}
