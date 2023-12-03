using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash2: BaseAttack
{
    public Slash2()
    {
        attackName = "Slash";
        attackDescription = "Fast slash attack with you Weapon.";
        attackDamage = 10f;
        attackCost = 0;
        attackAnimation = "BOSS01_ATAQ_01";
    }
}
