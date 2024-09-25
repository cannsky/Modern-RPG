using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mandeshire
{
    [System.Serializable]
    public class CameraSettings
    {
        [System.Serializable]
        public class CameraColliderSettings
        {
            public float cameraSphereRadius = 0.2f;
            public float cameraCollisionOffset = 0.2f;
            public float minimumCollisionOffset = 0.2f;
        }

        [SerializeField] public CameraColliderSettings cameraColliderSettings;
    }
}