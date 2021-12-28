using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class __SpineAnimationStart : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public SkeletonGraphic skeletonGraphic;
    public SkeletonGraphic skeletonGraphic2;
    public SkeletonGraphic skeletonGraphic3;
    public SkeletonGraphic skeletonGraphic4;
    public SkeletonGraphic skeletonGraphic5;

    public string nameanim;
    public string nameInput;

    public void PlayAnimation(string animName)
    {
        if (skeletonAnimation.AnimationState != null) skeletonAnimation.AnimationState.SetAnimation(0, animName, true);
    }

    public void PlayGraphicAnimation(string animName)
    {
        if (skeletonGraphic.AnimationState != null) skeletonGraphic.AnimationState.SetAnimation(0, nameanim, false);
    }

    public void PlayGraphicInput(string name)
    {
        if(skeletonGraphic2!=null)
        skeletonGraphic2.AnimationState.SetAnimation(0, name, false);
    }

    public void PlayGraphicInput2(string name)
    {
        if (skeletonGraphic3 != null)
            skeletonGraphic3.AnimationState.SetAnimation(0, name, false);
    }

    public void PlayGraficInputLoop(string name)
    {
        if (skeletonGraphic4 != null)
            skeletonGraphic4.AnimationState.SetAnimation(0, name, true);
    }

    public void PlayGraficInputLoop2(string name)
    {
        if (skeletonGraphic5 != null)
            skeletonGraphic5.AnimationState.SetAnimation(0, name, true);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(skeletonAnimation==null && skeletonGraphic==null)
            skeletonAnimation = GetComponent<SkeletonAnimation>();
    }
}
