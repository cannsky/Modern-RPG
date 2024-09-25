using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mandeshire
{
    public class CameraManager : MonoBehaviour
    {
        public CameraWorker cameraWorker;

        [SerializeField] public CameraSettings cameraSettings;

        private void Awake() => cameraWorker = new CameraWorker(this, cameraSettings);

        private void Start() => cameraWorker.StartCall();

        private void FixedUpdate() => cameraWorker.FixedUpdateCall();
    }
}