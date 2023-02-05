using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjastCollisionByLevel : MonoBehaviour
{
    InGameWallet wallet;
    public List<GameObject> collisionLevelList = new List<GameObject>();

    int beforeLevel;

    // Start is called before the first frame update
    void Start()
    {
        wallet = GameObject.FindWithTag("GameController").GetComponent<InGameWallet>();
        beforeLevel = wallet.PlayerLevel;

        InvisibleAllCollision();
        collisionLevelList[0]?.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if( wallet.PlayerLevel != beforeLevel )
        {
            ChangeCollisionByLevel();
        }
    }

    void ChangeCollisionByLevel()
    {
        InvisibleAllCollision();
        
        int i = 1;
        foreach( GameObject _col in collisionLevelList)
        {
            if( i == wallet.PlayerLevel )
            {
                _col.SetActive(true);
                beforeLevel = wallet.PlayerLevel;            
                return;
            }
            i++;
        }

        throw new System.Exception("AdjastCollisionByLevel : レベルに応じたコリジョンが設定されていません");
    }

    void InvisibleAllCollision()
    {
        foreach( GameObject _col in collisionLevelList)
        {
            _col.SetActive(false);
        }
    }

    public GameObject GetNowCollisionGameObject()
    {
        return collisionLevelList[ beforeLevel - 1 ];
    }
}
