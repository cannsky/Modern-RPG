using UnityEngine;

[System.Serializable]
public class EnemyMaterialSettings
{
    [SerializeField] public float dissolveSpeed = 1f;
    [SerializeField] public float dissolveChangeTime = 0.1f;
    [SerializeField] public float dissolveAnimationWaitTime = 1f;
    [SerializeField] public Material bodyOriginalMaterial;
    [SerializeField] public Material headOriginalMaterial;
    [SerializeField] public Material bodyDeathMaterial;
    [SerializeField] public Material headDeathMaterial;
    [SerializeField] public Material spawnMaterial;
    [SerializeField] public Renderer meshRenderer;
}
