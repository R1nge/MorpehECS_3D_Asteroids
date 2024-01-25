using _Assets.Scripts.Services.Spawners;
using _Assets.Scripts.Services.UIs.StateMachine;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class GameState : IGameState
    {
        private readonly UIStateMachine _uiStateMachine;
        private readonly PlayerSpawner _playerSpawner;
        private readonly AsteroidsSpawner _asteroidsSpawner;

        public GameState(GameStateMachine stateMachine, UIStateMachine uiStateMachine, PlayerSpawner playerSpawner,AsteroidsSpawner asteroidsSpawner)
        {
            _uiStateMachine = uiStateMachine;
            _playerSpawner = playerSpawner;
            _asteroidsSpawner = asteroidsSpawner;
        }

        public void Enter()
        {
            _uiStateMachine.SwitchState(UIStateType.InGame);
            _playerSpawner.Spawn();
            _asteroidsSpawner.Spawn();
        }

        public void Exit()
        {
            _playerSpawner.Destroy();
            _asteroidsSpawner.Destroy();
        }
    }
}