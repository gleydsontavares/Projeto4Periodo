using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash: BaseAttack
{
    public Slash()
    {
        attackName = "Slash";
        attackDescription = "Fast slash attack with you Weapon.";
        attackDamage = 10f;
        attackCost = 0;
    }
}
