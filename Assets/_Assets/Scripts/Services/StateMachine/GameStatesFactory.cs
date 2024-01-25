using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.Spawners;
using _Assets.Scripts.Services.StateMachine.States;
using _Assets.Scripts.Services.UIs.StateMachine;

namespace _Assets.Scripts.Services.StateMachine
{
    public class GameStatesFactory
    {
        private readonly UIStateMachine _uiStateMachine;
        private readonly PlayerSpawner _playerSpawner;
        private readonly AsteroidsSpawner _asteroidsSpawner;

        private GameStatesFactory(UIStateMachine uiStateMachine, PlayerSpawner playerSpawner, AsteroidsSpawner asteroidsSpawner)
        {
            _uiStateMachine = uiStateMachine;
            _playerSpawner = playerSpawner;
            _asteroidsSpawner = asteroidsSpawner;
        }

        public IGameState CreateInitState(GameStateMachine stateMachine)
        {
            return new InitState(stateMachine, _uiStateMachine);
        }

        public IGameState CreateGameState(GameStateMachine stateMachine)
        {
            return new GameState(stateMachine, _uiStateMachine, _playerSpawner, _asteroidsSpawner);
        }

        public IGameState CreateGameOverState(GameStateMachine stateMachine)
        {
            return new GameOverState(stateMachine);
        }
    }
}