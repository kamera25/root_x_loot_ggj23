using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureAnimationPresenter : MonoBehaviour
{
    Animator animator ;
    SukeFurnitureBehavior furnitureBehavior;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        furnitureBehavior = this.GetComponent<SukeFurnitureBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool( "hitcollision" , furnitureBehavior.IsHitCollision() );
        if( furnitureBehavior.IsSuked() )
        {
            animator.SetTrigger( "suked" ); 
            this.enabled = false;
        }
    }

}
