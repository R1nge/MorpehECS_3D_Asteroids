using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.UIs.StateMachine;
using UnityEngine;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class GameState : IGameState
    {
        private readonly UIStateMachine _uiStateMachine;
        private readonly PlayerFactory _playerFactory;
        private readonly AsteroidsSpawner _asteroidsSpawner;
        private GameObject _player;

        public GameState(GameStateMachine stateMachine, UIStateMachine uiStateMachine, PlayerFactory playerFactory,AsteroidsSpawner asteroidsSpawner)
        {
            _uiStateMachine = uiStateMachine;
            _playerFactory = playerFactory;
            _asteroidsSpawner = asteroidsSpawner;
        }

        public void Enter()
        {
            _uiStateMachine.SwitchState(UIStateType.InGame);
            _player = _playerFactory.Create();
            _asteroidsSpawner.Spawn();
        }

        public void Exit()
        {
            Object.Destroy(_player);
            //TODO: remove asteroids
        }
    }
}