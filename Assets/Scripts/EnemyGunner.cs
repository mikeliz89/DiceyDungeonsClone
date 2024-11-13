using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunner : Enemy
{
    public override void Attack()
    {
        // Erityinen hyökkäys Gunnerille
        Debug.Log($"{enemyName} smashes with a club and deals {damage} damage!");
    }

    protected override void Die()
    {
        // Trollille erityinen kuolemanlogiikka
        Debug.Log($"{enemyName} roars and collapses!");
        base.Die(); // Kutsuu perusluokan Die-metodia
    }
}
