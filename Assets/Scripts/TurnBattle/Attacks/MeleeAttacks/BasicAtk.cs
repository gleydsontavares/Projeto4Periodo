using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAtk: BaseAttack
{
    public BasicAtk()
    {
        attackName = "Slash";
        attackDescription = "Fast slash attack with you Weapon.";
        attackDamage = 10f;
        attackCost = 0;
        attackAnimation = "BasicAtk";
    }
}
