using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventSystem : MonoBehaviour
{
    public PlayerAnimationEventController playerAnimationEventController;
    public EnemyAnimationEventController enemyAnimationController;

    private void Awake()
    {
        if (transform.parent.tag == "Player") playerAnimationEventController = new PlayerAnimationEventController();
        else if (transform.parent.tag == "Enemy") enemyAnimationController = new EnemyAnimationEventController(transform.parent.GetComponent<EnemyAI>());
    }

    public void StartAttack(int value)
    {
        if (transform.parent.tag == "Player") playerAnimationEventController.StartAttack(value);
        else if (transform.parent.tag == "Enemy") enemyAnimationController.StartAttack();
    }

    public void EndAttack()
    {
        if (transform.parent.tag == "Player") playerAnimationEventController.EndAttack();
        else if (transform.parent.tag == "Enemy") enemyAnimationController.EndAttack();
    }

    public void PlaySkillVFX(int value)
    {
        if (transform.parent.tag == "Enemy") enemyAnimationController.PlaySkillVFX(value);
    }

    public void ChangeWeaponSlot(int value)
    {
        if (transform.parent.tag == "Player") playerAnimationEventController.ChangeWeaponSlot(value);
    }

    public void CheckExtraAttack()
    {
        if (transform.parent.tag == "Player") playerAnimationEventController.CheckExtraAttack(gameObject);
    }

    public void StopCheckExtraAttack()
    {
        if (transform.parent.tag == "Player") playerAnimationEventController.StopCheckExtraAttack(gameObject);
    }

    public void PlayFootstepAudio(int footstepSFXValue)
    {
        return;
        if (transform.parent.tag == "Player") playerAnimationEventController.PlayFootstepAudio(gameObject, footstepSFXValue);
    }
}
