using UnityEngine;

namespace Entities.Attack
{
    public class AttackSpeed : IAttack
    {
        public void Shoot()
        {
            Debug.Log("Attack Speed");
        }
    }
}