using System;

public class PlayerAttacking : Attacking
{
    public Action OnAttackAction;

    public override void Attack()
    {
        OnAttackAction?.Invoke();
    }
}
