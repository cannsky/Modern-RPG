using System.Collections;
using UnityEngine;

public class EnemyMaterial
{
    public class MaterialState
    {
        public EnemyWorker enemyWorker;

        public EnemyMaterialSettings materialSettings;

        public Material bodyOriginalMaterial, headOriginalMaterial, bodyDeathMaterial, headDeathMaterial, spawnMaterial;

        public bool isVFXStarted;

        public MaterialState(EnemyWorker enemyWorker, EnemyMaterialSettings materialSettings)
        {
            this.enemyWorker = enemyWorker;
            this.materialSettings = materialSettings;
            bodyOriginalMaterial = materialSettings.bodyOriginalMaterial;
            headOriginalMaterial = materialSettings.headOriginalMaterial;
            bodyDeathMaterial = materialSettings.bodyDeathMaterial;
            headDeathMaterial = materialSettings.headDeathMaterial;
            spawnMaterial = materialSettings.spawnMaterial;
        }
    }

    public MaterialState materialState;

    public EnemyMaterial(EnemyWorker enemyWorker) => materialState = new MaterialState(enemyWorker, enemyWorker.enemyAI.enemySettings.materialSettings);

    public void Dissolve() => materialState.enemyWorker.enemyAI.StartCoroutine(HandleDissolve());

    public void ReverseDissolve() => materialState.enemyWorker.enemyAI.StartCoroutine(IncreaseDissolveThreshold());

    public float IncreaseThreshold() => materialState.materialSettings.meshRenderer.material.GetFloat("_threshold") + materialState.materialSettings.dissolveSpeed * Time.deltaTime;

    public float DecreaseThreshold() => materialState.materialSettings.meshRenderer.material.GetFloat("_threshold") + materialState.materialSettings.dissolveSpeed * Time.deltaTime;

    public void ChangeMaterial(Material material) => materialState.materialSettings.meshRenderer.materials = new Material[] { material };

    public void ChangeMaterials(Material bodyMaterial, Material headMaterial) => materialState.materialSettings.meshRenderer.materials = new Material[] { headMaterial, bodyMaterial };

    public IEnumerator IncreaseDissolveThreshold()
    {
        ChangeMaterial(materialState.materialSettings.spawnMaterial);
        while (materialState.materialSettings.meshRenderer.material.GetFloat("_threshold") < 1f)
        {
            materialState.materialSettings.meshRenderer.material.SetFloat("_threshold", IncreaseThreshold());
            yield return new WaitForSeconds(materialState.materialSettings.dissolveChangeTime);
        }
        ChangeMaterial(materialState.materialSettings.bodyOriginalMaterial);
    }

    public IEnumerator HandleDissolve()
    {
        yield return new WaitForSeconds(materialState.materialSettings.dissolveAnimationWaitTime);
        ChangeMaterials(materialState.bodyDeathMaterial, materialState.headDeathMaterial);
        while (materialState.materialSettings.meshRenderer.material.GetFloat("_threshold") < 1f)
        {
            materialState.materialSettings.meshRenderer.materials[0].SetFloat("_threshold", 
                materialState.materialSettings.meshRenderer.materials[0].GetFloat("_threshold") + materialState.materialSettings.dissolveSpeed * Time.deltaTime);
            materialState.materialSettings.meshRenderer.materials[1].SetFloat("_threshold", 
                materialState.materialSettings.meshRenderer.materials[1].GetFloat("_threshold") + materialState.materialSettings.dissolveSpeed * Time.deltaTime);
            if(materialState.materialSettings.meshRenderer.material.GetFloat("_threshold") > 0.35f && !materialState.isVFXStarted)
            {
                materialState.isVFXStarted = true;
                materialState.enemyWorker.enemyVFX.vfxState.enemyDissolveVFX.PlayVFX(1);
            }
            yield return new WaitForSeconds(materialState.materialSettings.dissolveChangeTime);
        }
        materialState.enemyWorker.enemyAI.DestroyItself();
    }
}