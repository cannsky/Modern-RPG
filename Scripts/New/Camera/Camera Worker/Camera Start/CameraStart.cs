using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mandeshire
{
    public class CameraStart
    {
        public class StartState
        {
            public CameraWorker cameraWorker;

            public StartState(CameraWorker cameraWorker)
            {
                this.cameraWorker = cameraWorker;
            }
        }

        public StartState startState;

        public CameraStart(CameraWorker cameraWorker) => startState = new StartState(cameraWorker);

        public void Start() => startState.cameraWorker.cameraCollider.Start();
    }
}
