using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mandeshire
{
    public class CameraFixedUpdate
    {
        public class FixedUpdateState
        {
            public CameraWorker cameraWorker;
            public float delta;

            public FixedUpdateState(CameraWorker cameraWorker)
            {
                this.cameraWorker = cameraWorker;
            }
        }

        public FixedUpdateState fixedUpdateState;

        public CameraFixedUpdate(CameraWorker cameraWorker) => fixedUpdateState = new FixedUpdateState(cameraWorker);

        public void FixedUpdate()
        {
            fixedUpdateState.delta = Time.deltaTime;
            fixedUpdateState.cameraWorker.cameraCollider.FixedUpdate(fixedUpdateState.delta);
        }
    }
}