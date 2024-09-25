using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTester : MonoBehaviour
{
    public bool testDamage;
    public bool testDeath;
    public bool testRevive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (testDamage)
        {
            TestDamage();
            testDamage = false;
        }

        if (testRevive)
        {
            Player.Instance.playerWorker.playerStats.statsState.playerHealthStats.Revive();
            testRevive = false;
        }
    }

    public void TestDamage()
    {
        Player.Instance.playerWorker.playerStats.statsState.playerHealthStats.TakeDamage(5);
    }
}
