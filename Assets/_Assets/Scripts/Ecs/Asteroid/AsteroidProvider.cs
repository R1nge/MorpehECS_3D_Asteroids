using _Assets.Scripts.Ecs.Health;
using _Assets.Scripts.Ecs.Requests;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Asteroid
{
    public class AsteroidProvider : MonoProvider<AsteroidComponent>
    {
        private Request<DamageRequest> _damageRequest;

        protected override void Initialize() => _damageRequest = World.Default.GetRequest<DamageRequest>();

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out HealthProvider healthProvider))
            {
                //Sends a request to be consumed by only one other system
                if (healthProvider.Entity != null)
                {
                    _damageRequest.Publish(new DamageRequest
                    {
                        TargetEntityId = healthProvider.Entity.ID,
                        Damage = 1,
                        IsPlayer = false
                    });
                }
            }
        }
    }
}