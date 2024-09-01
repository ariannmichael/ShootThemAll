using Entities.Attack;

namespace Strategies
{
    public class AttackStrategy
    {
        private IAttack _playerAttack;

        public void SetStrategy(IAttack newAttack)
        {
            _playerAttack = newAttack;
        }

        public void Shoot()
        {
            _playerAttack.Shoot();
        }
    }
}