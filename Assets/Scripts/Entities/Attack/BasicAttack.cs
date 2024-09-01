using UnityEngine;

namespace Entities.Attack
{
    public class BasicAttack : IAttack
    {
        public void Shoot()
        {
            Debug.Log("Attack Basic");
        }
    }
}