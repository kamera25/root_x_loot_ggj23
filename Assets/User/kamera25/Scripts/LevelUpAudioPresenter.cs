using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpAudioPresenter : MonoBehaviour
{
    AudioSource audioSource;
    InGameWallet playerStatus;

    int beforeLevel = 1;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        playerStatus = this.GetComponent<InGameWallet>();
    }

    // Update is called once per frame
    void Update()
    {
        if( playerStatus.PlayerLevel > beforeLevel )
        {
            audioSource.Play();
            beforeLevel = playerStatus.PlayerLevel;
        }
    }
}
