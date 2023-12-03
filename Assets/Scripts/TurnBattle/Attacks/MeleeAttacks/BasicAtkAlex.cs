using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAtkAlex: BaseAttack
{
    public BasicAtkAlex()
    {
        attackName = "Slash";
        attackDescription = "Fast slash attack with you Weapon.";
        attackDamage = 10f;
        attackCost = 0;
        attackAnimation = "BasicAtk";
    }
}
