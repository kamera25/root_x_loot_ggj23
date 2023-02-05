using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSEPresenter : MonoBehaviour
{
    AudioSource playerSE;
    [SerializeField]
    AdjastCollisonScaleByInput collisionSuke;

    float volume = 0;
    float soundVolumeRate = 3F;

    // Start is called before the first frame update
    void Start()
    {
        playerSE = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float volumeUpDown = collisionSuke.IsSuked() ? soundVolumeRate : -soundVolumeRate;
        volume = Mathf.Clamp( volume + volumeUpDown * Time.deltaTime, 0F, 1F);
        playerSE.volume = Mathf.Clamp( volume, 0F, 1F);
    }
}
