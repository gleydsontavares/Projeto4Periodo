using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAtkOliver: BaseAttack
{
    public BasicAtkOliver()
    {
        attackName = "Slash";
        attackDescription = "Fast slash attack with you Weapon.";
        attackDamage = 10f;
        attackCost = 0;
        attackAnimation = "BasicAtk";
    }
}
