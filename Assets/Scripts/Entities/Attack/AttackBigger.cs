using UnityEngine;

namespace Entities.Attack
{
    public class AttackBigger : IAttack
    {
        public void Shoot()
        {
            Debug.Log("Attack Bigger");
        }
    }
}