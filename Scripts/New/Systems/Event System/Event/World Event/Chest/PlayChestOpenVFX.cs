using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event/World Event/Chest Event/Play Chest Open VFX", order = 2)]
public class PlayChestOpenVFX : WorldEvent
{

    [SerializeField] 
    public float waitTime = 0.4f;
    public override bool HandleEvent()
    {
        if (base.isEffectItSelf)
            if (!PlayVFX()) return false;
        return true;
    }
    public bool PlayVFX()
    {
        EnumerationController.Instance.HandleEnumeration(PlayVFXAfterWaitTime());
        return true;
    }

    public IEnumerator PlayVFXAfterWaitTime()
    {
        yield return new WaitForSeconds(waitTime);
        ChestParticleSystem chest = base.gameObjectSelf.transform.parent.gameObject.GetComponent<ChestParticleSystem>();
        chest.particles.Play();
        chest.emis.enabled = true;
    }
}