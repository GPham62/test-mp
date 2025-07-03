using System;
using UnityEngine;

public struct DamageTransfer
{
    public float damageStat;
    public event Action<DamageTransfer> OnDealDamageAction;

    public DamageTransfer(DamageTransfer damageTransfer)
    {
        this.damageStat = damageTransfer.damageStat;
        this.OnDealDamageAction = damageTransfer.OnDealDamageAction;
    }
}
