using _Assets.Scripts.Services.Factories;
using UnityEngine;
using VContainer.Unity;

namespace _Assets.Scripts.Services.Spawners
{
    public class PlayerSpawner : IInitializable
    {
        private readonly PlayerFactory _playerFactory;
        private readonly PlayerLivesService _playerLivesService;
        private GameObject _player;

        private PlayerSpawner(PlayerFactory playerFactory, PlayerLivesService playerLivesService)
        {
            _playerFactory = playerFactory;
            _playerLivesService = playerLivesService;
        }

        public void Initialize() => _playerLivesService.OnLivesChanged += Respawn;

        public void Spawn() => _player = _playerFactory.Create();

        private void Respawn(int lives)
        {
            if (lives > 0)
            {
                _player.GetComponent<Rigidbody>().velocity = Vector3.zero;
                _player.transform.position = Vector3.zero;
            }
        }

        public void Destroy() => Object.Destroy(_player);
    }
}