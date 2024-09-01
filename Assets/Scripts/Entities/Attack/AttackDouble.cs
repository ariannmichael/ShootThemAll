using UnityEngine;

namespace Entities.Attack
{
    public class AttackDouble : IAttack
    {
        public void Shoot()
        {
            Debug.Log("Attack Double");
        }
    }
}