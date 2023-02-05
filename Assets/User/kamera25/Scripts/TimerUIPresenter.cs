using UnityEngine;
using TMPro;

public class TimerUIPresenter : MonoBehaviour
{
    [SerializeField]
    TMP_Text timerText;
    GameTimer timer;

    void Start()
    {
        timer = this.GetComponent<GameTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = timer.Timer.ToString("0");
    }
}
