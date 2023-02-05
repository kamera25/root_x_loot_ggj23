using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleSmokebySuked : MonoBehaviour
{
    InGameWallet wallet;
    AdjastCollisonScaleByInput collisionData;
    [SerializeField]
    List<GameObject> smokeList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        wallet = GameObject.FindWithTag("GameController").GetComponent<InGameWallet>();
        collisionData = this.GetComponent<AdjastCollisonScaleByInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if( collisionData.IsSuked() )
        {
            smokeList[wallet.PlayerLevel - 1]?.SetActive(true);
        }
        else
        {
            smokeList[wallet.PlayerLevel - 1]?.SetActive(false);
        }
    }
}
