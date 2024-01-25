using _Assets.Scripts.Ecs.Health;
using _Assets.Scripts.Ecs.Movement;
using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace _Assets.Scripts.Ecs
{
    public class Bullet : MonoProvider<MovementComponent>
    {
        [SerializeField] private int damage;
        
        private void Awake() => Destroy(gameObject, 5f);

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out HealthProvider healthProvider))
            {
                healthProvider.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}