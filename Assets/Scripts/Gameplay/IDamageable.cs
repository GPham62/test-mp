using UnityEngine;

public interface IDamageable
{
    bool TakeDamage(DamageTransfer damageTransfer);

    bool IsAlive();
}
