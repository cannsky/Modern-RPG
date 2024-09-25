using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mandeshire
{
    public class CameraCollider
    {
        public class ColliderState
        {
            public PlayerCamera playerCamera;
            public CameraWorker cameraWorker;

            public Vector3 collisionDirection;
            public RaycastHit raycastHit;

            public float collisionTargetPosition, collisionNewDistance;
            public float cameraSphereRadius, cameraCollisionOffset, minimumCollisionOffset;

            public ColliderState(CameraWorker cameraWorker, CameraSettings cameraSettings)
            {
                this.cameraWorker = cameraWorker;
                cameraSphereRadius = cameraSettings.cameraColliderSettings.cameraSphereRadius;
                cameraCollisionOffset = cameraSettings.cameraColliderSettings.cameraCollisionOffset;
                minimumCollisionOffset = cameraSettings.cameraColliderSettings.minimumCollisionOffset;
            }
        }

        public ColliderState colliderState;

        public CameraCollider(CameraWorker cameraWorker, CameraSettings cameraSettings) => colliderState = new ColliderState(cameraWorker, cameraSettings);

        public void Start() => colliderState.playerCamera = Player.Instance.playerWorker.playerCamera;

        public void FixedUpdate(float delta) => HandleCameraCollision(delta);

        public void HandleCameraCollision(float delta)
        {
            colliderState.collisionTargetPosition = colliderState.playerCamera.cameraState.playerCameraFollow.cameraFollowState.defaultPosition;
            colliderState.collisionDirection = colliderState.playerCamera.cameraState.playerCameraFollow.cameraFollowState.cameraTransform.position - colliderState.playerCamera.cameraState.playerCameraFollow.cameraFollowState.cameraPivotTransform.position;
            colliderState.collisionDirection.Normalize();
            if (Physics.SphereCast(
                colliderState.playerCamera.cameraState.playerCameraFollow.cameraFollowState.cameraPivotTransform.position,
                colliderState.cameraSphereRadius,
                colliderState.collisionDirection,
                out colliderState.raycastHit,
                Mathf.Abs(colliderState.collisionTargetPosition),
                colliderState.playerCamera.cameraState.ignoreLayers))
            {
                colliderState.collisionNewDistance = Vector3.Distance(colliderState.playerCamera.cameraState.playerCameraFollow.cameraFollowState.cameraPivotTransform.position, colliderState.raycastHit.point);
                colliderState.collisionTargetPosition = -(colliderState.collisionNewDistance - colliderState.cameraCollisionOffset);
            }

            if (Mathf.Abs(colliderState.collisionTargetPosition) < colliderState.minimumCollisionOffset) colliderState.collisionTargetPosition = -colliderState.minimumCollisionOffset;

            colliderState.playerCamera.cameraState.playerCameraFollow.cameraFollowState.cameraTransformPosition.z = Mathf.Lerp(colliderState.playerCamera.cameraState.playerCameraFollow.cameraFollowState.cameraTransform.localPosition.z, colliderState.collisionTargetPosition, delta / 0.2f);
            colliderState.playerCamera.cameraState.playerCameraFollow.cameraFollowState.cameraTransform.localPosition = colliderState.playerCamera.cameraState.playerCameraFollow.cameraFollowState.cameraTransformPosition;
        }
    }
}