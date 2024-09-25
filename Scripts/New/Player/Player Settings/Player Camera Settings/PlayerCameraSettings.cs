using UnityEngine;

[System.Serializable]
public class PlayerCameraSettings
{
    [SerializeField] public Transform cameraTransform;
    [SerializeField] public Transform cameraPivotTransform;
    [SerializeField] public Transform cameraHolderTransform;
    [SerializeField] public Transform targetTransform;
    [SerializeField] public float lookSpeed = 0.1f;
    [SerializeField] public float followSpeed = 0.1f;
    [SerializeField] public float pivotSpeed = 0.03f;
    [SerializeField] public float minimumPivot = -35f;
    [SerializeField] public float maximumPivot = 35f;
    [System.Serializable]
    public class PlayerCameraHeightSettings
    {
        [SerializeField] public float lockedPivotPosition = -4;
        [SerializeField] public float unlockedPivotPosition = -3;
    }
    [SerializeField] public PlayerCameraHeightSettings cameraHeightSettings;
}
