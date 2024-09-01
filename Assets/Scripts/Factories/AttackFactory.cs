using Entities.Attack;

namespace Factories
{
    public class AttackFactory
    {
        public IAttack Create(string powerUp)
        {
            switch (powerUp)
            {
                case "double":
                    return new AttackDouble();
                case "bigger":
                    return new AttackBigger();
                case "speed":
                    return new AttackSpeed();
                default:
                    return new BasicAttack();
            }
        }
    }
}