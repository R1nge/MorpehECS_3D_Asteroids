using _Assets.Scripts.Ecs.Events;
using _Assets.Scripts.Ecs.Health;
using _Assets.Scripts.Ecs.Movement;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace _Assets.Scripts.Ecs
{
    public class Bullet : MonoProvider<MovementComponent>
    {
        [SerializeField] private int damage;
        private Event<DamagedEvent> _damagedEvent;

        private void Awake()
        {
            Destroy(gameObject, 5f);
            _damagedEvent = World.Default.GetEvent<DamagedEvent>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out HealthProvider healthProvider))
            {
                //TODO: Possible null?
                _damagedEvent.NextFrame(new DamagedEvent
                {
                    targetEntityId = healthProvider.Entity.ID,
                    damage = damage
                });
                
                Destroy(gameObject);
            }
        }
    }
}