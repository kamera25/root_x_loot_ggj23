using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureAudioPresenter : MonoBehaviour
{
    AudioSource furnitureSE;
    SukeFurnitureBehavior sukeFurniture;

    float volume = 0;
    float soundVolumeRate = 10F;

    [SerializeField]
    AudioClip sukedSE;

    // Start is called before the first frame update
    void Start()
    {
        furnitureSE = this.GetComponent<AudioSource>();
        sukeFurniture = this.GetComponent<SukeFurnitureBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        ControllSEWhileSuked();

        if( sukeFurniture.IsSuked())
        {
            furnitureSE?.PlayOneShot(sukedSE);
            this.enabled = false;
            return;
        }
    }

    void ControllSEWhileSuked()
    {
        float volumeUpDown = sukeFurniture.IsHitCollision() ? soundVolumeRate : -soundVolumeRate;
        volume = Mathf.Clamp( volume + volumeUpDown * Time.deltaTime, 0F, 1F);
        furnitureSE.volume = Mathf.Clamp01( volume );

        // Adjast se pitch.
        float suctionPower = sukeFurniture.GetSuctionPowerByCurve();
        furnitureSE.pitch = Mathf.Clamp01( suctionPower / 30F );
    }
}
