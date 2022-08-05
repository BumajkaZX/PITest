
public class BotAttack 
{
    public void Attack(IDamagable target, float damage)
    {
        target.GiveDamage(damage);
    }
}
