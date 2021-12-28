using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class __PlaySpineAnime : StateMachineBehaviour
{
    public string animationName;
    public float speed;
    public bool isLoop;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!stateInfo.IsName("End"))
        {
            var anim = animator.GetComponent<SkeletonGraphic>();
            anim.AnimationState.SetAnimation(0, animationName, isLoop).TimeScale = speed;
        }
    }
}
