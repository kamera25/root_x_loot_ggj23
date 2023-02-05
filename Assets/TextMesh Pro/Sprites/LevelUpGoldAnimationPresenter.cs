using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpGoldAnimationPresenter : MonoBehaviour
{
    InGameWallet playerStatus;
    [SerializeField]
    Animator anim;
    int beforeLevel = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerStatus = this.GetComponent<InGameWallet>();
    }

    // Update is called once per frame
    void Update()
    {
        if( playerStatus.PlayerLevel > beforeLevel )
        {
            anim.SetTrigger("levelUp");
            beforeLevel = playerStatus.PlayerLevel;
        }
    }
}
