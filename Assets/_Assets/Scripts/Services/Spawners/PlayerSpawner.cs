using _Assets.Scripts.Services.Factories;
using UnityEngine;

namespace _Assets.Scripts.Services.Spawners
{
    public class PlayerSpawner
    {
        private readonly PlayerFactory _playerFactory;
        private GameObject _player;

        private PlayerSpawner(PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }
        
        public void Spawn()
        {
            _player = _playerFactory.Create();
        }

        public void Respawn()
        {
            //TODO: player spawner to be able to spawn/respawn the player, depending on the lives left
        }

        public void Destroy() => Object.Destroy(_player);
    }
}