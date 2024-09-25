using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationErrorCompensator : AnimationErrorCompensator
{
    //[SerializeField] Transform tempPoint;
    //[SerializeField] [Range(0, 180)] float visionAngle;
    //[Tooltip(tooltip:"Increasing this would affect performance positively although it might also break the game")]
    //[SerializeField] float deltaAngle = 1f;
    //[SerializeField] [Range(0, 1)] float errorMargin;
    //int mask;



    static (PlayerAnimationErrorCompensator instance1, PlayerAnimationErrorCompensator instance2) instances = (null, null);
    public static (PlayerAnimationErrorCompensator instance1, PlayerAnimationErrorCompensator instance2) Instances { get => instances; }

    private void Awake()
    {
        if (instances.instance1 == null)
        {
            instances.instance1 = this;
            DontDestroyOnLoad(this);
        }
        else if (instances.instance2 == null)
        {
            instances.instance2 = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(this);
    }

    protected override void Start()
    {
        base.Start();
        controller = Player.Instance.GetComponent<CharacterController>();
        //mask = LayerMask.GetMask("Terrain");
        //action = () =>
        //{
        //    if (GetRootMotionAvailable())
        //    {
        //        Vector3 oldPos = transform.parent.position;
        //        Vector3 estimatedPos = oldPos + anim.deltaPosition;
        //        anim.applyRootMotion = true;
        //        controller.SimpleMove(anim.deltaPosition / Time.deltaTime);
        //    }
        //    else
        //        anim.applyRootMotion = false;
        //};

        ////idleAction = () =>
        ////{
        ////    controller.attachedRigidbody?.AddForce(Vector3.down, ForceMode.Impulse);
        ////};
    }

    protected override bool GetRootMotionAvailable()
    {
        return false;
    }

    //private bool IsPlayerBlocked()
    //{
    //    var colliders = Physics.OverlapCapsule(controller.bounds.min, controller.bounds.max, controller.radius, Helper.GetEnemyAndNPCLayer(),QueryTriggerInteraction.Ignore);
    //    if (colliders.Length > 0)
    //        Debug.Log("Enemy found");

    //    bool touching = false;
    //    bool movingTowardsEnemy = false;
    //    Vector3 deltaVector = new Vector3(0, deltaAngle, 0);

    //    foreach (var collider in colliders)
    //    {
    //        if (controller.bounds.Intersects(collider.bounds))//One more level of protection
    //        {
    //            Debug.Log("Enemy is guaranteed to be in the boundaries of our collider");
    //            touching = true;
    //            Transform left = Instantiate<Transform>(tempPoint, transform.position, transform.rotation, null);
    //            Transform right = Instantiate<Transform>(tempPoint, transform.position, transform.rotation, null);

    //            left.Rotate(new Vector3(0, -visionAngle / 2, 0));
    //            right.Rotate(new Vector3(0, visionAngle / 2, 0));

    //            int counter = 0;
    //            do
    //            {
    //                bool CheckRay(Vector3 direction) => Physics.CapsuleCast(controller.bounds.min, controller.bounds.max, deltaAngle, direction, controller.radius + errorMargin, Helper.GetEnemyAndNPCLayer(), QueryTriggerInteraction.Ignore);

    //                if (CheckRay(left.forward) || CheckRay(right.forward)) movingTowardsEnemy = true;

    //                left.Rotate(deltaVector);
    //                right.Rotate(-deltaVector);
    //                Physics.SyncTransforms();
    //                counter++;
    //            } while (counter<=visionAngle/2 || movingTowardsEnemy);

    //            Destroy(left);
    //            Debug.Log("I shall be destroyed");
    //            Destroy(right);
    //            if (movingTowardsEnemy) break;
    //        }
    //    }

    //    return touching && movingTowardsEnemy;
    //}
}