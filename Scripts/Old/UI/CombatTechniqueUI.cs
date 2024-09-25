using System.Linq;
using UnityEngine;

public class CombatTechniqueUI : MonoBehaviour
{
    /*
    public static CombatTechniqueUI Instance;

    PlayerCombatTechnique combatTechnique;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else Destroy(this);
    }

    private void Start()
    {
        combatTechnique = Player.Instance.playerWorker.playerCombatTechnique;
        combatTechnique.Initialize();
        gameObject.SetActive(false);
    }

    public void ToggleMenu()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        InputManager.Instance.Mode = gameObject.activeSelf ? UIMode.CombatTechniques : UIMode.None;
    }

    public void ChangeToLightningSpeed() => combatTechnique.ChangeCombatTechnique(PlayerCombatTechniqueSettings.CombatTechnique.CombatTechniqueType.LightningSpeed);
    public void ChangeToRockDurability() => combatTechnique.ChangeCombatTechnique(PlayerCombatTechniqueSettings.CombatTechnique.CombatTechniqueType.RockDurability);
    public void ChangeToWaterVortex() => combatTechnique.ChangeCombatTechnique(PlayerCombatTechniqueSettings.CombatTechnique.CombatTechniqueType.WaterVortex);

    */
}