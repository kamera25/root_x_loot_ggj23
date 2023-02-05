using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeUpBehavior : MonoBehaviour
{
    GameTimer timer;
    InGameWallet wallet;

    // Start is called before the first frame update
    void Start()
    {
        timer = this.GetComponent<GameTimer>();
        wallet = this.GetComponent<InGameWallet>();
    }

    // Update is called once per frame
    void Update()
    {
        if( timer.Timer < 0F)
        {
            SceneManager.sceneLoaded += TransitResultScene;
            SceneManager.LoadScene("Result");
        }
    }

    void TransitResultScene( Scene next, LoadSceneMode mode)
    {
            var _resultManager = GameObject.FindWithTag("GameController").GetComponent<ResultScorePresenter>();
            _resultManager.SetResultScore( wallet.Gold );
            SceneManager.sceneLoaded -= TransitResultScene;
    }
}
