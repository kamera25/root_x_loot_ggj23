using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPresenter : MonoBehaviour
{

    [SerializeField] private Animator _animator;
    [SerializeField] private AdjastCollisonScaleByInput collisionData;
    MoveController moveController;
    // Start is called before the first frame update
    void Start()
    {
        moveController = this.GetComponent<MoveController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayWalkAnimation( moveController.MoveInputValue );
        PlaySukeAnimation();
    }

    void PlayWalkAnimation( Vector3 moveInputValue)
    {
        if( Mathf.Abs( moveInputValue.x ) > 0.7F || Mathf.Abs( moveInputValue.y ) > 0.7F)
        {
            _animator.SetBool("isWalk", true);
        }
        else
        {
            _animator.SetBool("isWalk", false);
        }
    }

    void PlaySukeAnimation()
    {
        _animator.SetBool("isSuked", collisionData.IsSuked());
    }
}
