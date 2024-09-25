using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class EnemyBarSettings
{
    [System.Serializable]
    public class EnemyHealthBarSettings
    {
        [SerializeField] public GameObject healthBarGameObject;
        [SerializeField] public Image healthBarFillImage;
    }

    [SerializeField] public EnemyHealthBarSettings healthBarSettings;
}
