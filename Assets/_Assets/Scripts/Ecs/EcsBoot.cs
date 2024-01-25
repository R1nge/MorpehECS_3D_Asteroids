using _Assets.Scripts.Ecs.Score;
using _Assets.Scripts.Ecs.Shooting;
using _Assets.Scripts.Services;
using _Assets.Scripts.Services.Factories;
using Scellecs.Morpeh;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Ecs
{
    public class EcsBoot : Installer
    {
        [SerializeField] private PlayerShootingSystem playerShootingSystem;
        [SerializeField] private ScoreSystem scoreSystem;
        [Inject] private BulletFactory _bulletFactory;
        [Inject] private ScoreService _scoreService;

        private void Start()
        {
            playerShootingSystem.Inject(_bulletFactory);
            scoreSystem.Inject(_scoreService);
        }
    }
}