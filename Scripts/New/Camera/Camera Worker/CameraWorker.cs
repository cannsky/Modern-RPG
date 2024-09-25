using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mandeshire
{
    public class CameraWorker
    {
        public CameraManager camera;
        public CameraCollider cameraCollider;
        public CameraFixedUpdate cameraFixedupdate;
        public CameraStart cameraStart;

        public CameraWorker(CameraManager camera, CameraSettings cameraSettings)
        {
            this.camera = camera;

            cameraCollider = new CameraCollider(this, cameraSettings);
            cameraFixedupdate = new CameraFixedUpdate(this);
            cameraStart = new CameraStart(this);
        }

        public void FixedUpdateCall() => cameraFixedupdate.FixedUpdate();

        public void StartCall() => cameraStart.Start();
    }
}