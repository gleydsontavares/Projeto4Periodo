using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetType
{
    Enemy,
    Ally
}

[System.Serializable]
public class BaseAttack: MonoBehaviour
{
    public string attackName; //name
    public string attackDescription;
    public float attackDamage; //base Damage 15, mellee LvL 10 stamina 35 = basedmg + stamina + LvL = 60
    public float attackCost; //Mana Cost
    public string attackAnimation;
    public string magicAttackAnimation;
    public TargetType targetType;
    
}
