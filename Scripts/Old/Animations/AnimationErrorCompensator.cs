using System;
using UnityEngine;

public class AnimationErrorCompensator : MonoBehaviour
{
    protected CharacterController controller;

    protected Animator anim;
    protected Action action;
    protected Action idleAction;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();

        //idleAction = () =>
        //{
        //    controller.attachedRigidbody?.AddForce(Vector3.down, ForceMode.Impulse);
        //};
    }

    private void OnAnimatorMove()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Idle") || anim.GetCurrentAnimatorStateInfo(0).IsTag("Idle 2"))
            idleAction?.Invoke();
        else
            action?.Invoke();
    }

    protected virtual bool GetRootMotionAvailable()
    {
        return false;
    }
}
