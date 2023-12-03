using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueBasico: BaseAttack
{
    public AtaqueBasico()
    {
        attackName = "AtaqueBasico";
        attackDescription = "Realiza um ataque basico.";
        attackDamage = 1f;
        attackCost = 0;
        attackAnimation = "ataque01";
    }
}
