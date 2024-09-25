using UnityEngine;
using System;

public class EnemyAnimationErrorCompensator : AnimationErrorCompensator
{
    protected override bool GetRootMotionAvailable() =>
        !(anim.GetCurrentAnimatorStateInfo(0).IsName("Walk Backwards") ||
        anim.GetCurrentAnimatorStateInfo(0).IsName("Walk") ||
        anim.GetCurrentAnimatorStateInfo(0).IsName("Rotate Left") ||
        anim.GetCurrentAnimatorStateInfo(0).IsName("Rotate Right"));

    protected override void Start()
    {
        base.Start();
        controller = transform.parent.GetComponent<CharacterController>();
    }
}