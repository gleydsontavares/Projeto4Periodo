using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oliverAtk : BaseAttack
{
    public oliverAtk()
    {
        attackName = "Fire 1";
        attackDescription = "Basic Fire Spell which burns nothing.";
        attackDamage = 20f;
        attackCost = 10f;
        
        magicAttackAnimation = "MagicAttack";
    }
}
