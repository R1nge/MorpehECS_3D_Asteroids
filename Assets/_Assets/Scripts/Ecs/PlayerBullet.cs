﻿using _Assets.Scripts.Ecs.Health;
using _Assets.Scripts.Ecs.Movement;
using _Assets.Scripts.Ecs.Requests;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace _Assets.Scripts.Ecs
{
    public class PlayerBullet : MonoProvider<MovementComponent>
    {
        [SerializeField] private int damage;
        private Request<DamageRequest> _damageRequest;

        protected override void Initialize()
        {
            Destroy(gameObject, 5f);
            _damageRequest = World.Default.GetRequest<DamageRequest>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out HealthProvider healthProvider))
            {
                //Sends a request to be consumed by only one other system
                _damageRequest.Publish(new DamageRequest
                {
                    //TODO: Possible null?
                    TargetEntityId = healthProvider.Entity.ID,
                    Damage = damage,
                    IsPlayer = true
                });
            }
            
            Destroy(gameObject);
        }
    }
}