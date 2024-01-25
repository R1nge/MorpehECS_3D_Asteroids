using _Assets.Scripts.Ecs.Damage;
using _Assets.Scripts.Ecs.Score;
using _Assets.Scripts.Ecs.Shooting;
using _Assets.Scripts.Services;
using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.Spawners;
using _Assets.Scripts.Services.StateMachine;
using Scellecs.Morpeh;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Ecs
{
    public class EcsBoot : Installer
    {
        [SerializeField] private PlayerShootingSystem playerShootingSystem;
        [SerializeField] private ScoreSystem scoreSystem;
        [SerializeField] private OnDamageSpawnNewAsteroid onDamageSpawnNewAsteroid;
        [SerializeField] private OnDamageGameOverSystem onDamageGameOverSystem;
        [Inject] private BulletFactory _bulletFactory;
        [Inject] private ScoreService _scoreService;
        [Inject] private AsteroidsSpawner _asteroidsSpawner;
        [Inject] private GameStateMachine _gameStateMachine;

        private void Start()
        {
            playerShootingSystem.Inject(_bulletFactory);
            scoreSystem.Inject(_scoreService);
            onDamageSpawnNewAsteroid.Inject(_asteroidsSpawner);
            onDamageGameOverSystem.Inject(_gameStateMachine);
        }
    }
}