using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Health
{
    public class HealthProvider : MonoProvider<HealthComponent>
    {
        public void TakeDamage(int damage)
        {
            Entity.GetComponent<HealthComponent>().health -= damage;
            Debug.Log($"Taken damage; Current health: {Entity.GetComponent<HealthComponent>().health}");
        }
    }
}