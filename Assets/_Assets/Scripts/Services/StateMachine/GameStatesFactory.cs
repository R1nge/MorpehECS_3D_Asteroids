using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.StateMachine.States;
using _Assets.Scripts.Services.UIs.StateMachine;

namespace _Assets.Scripts.Services.StateMachine
{
    public class GameStatesFactory
    {
        private readonly UIStateMachine _uiStateMachine;
        private readonly PlayerFactory _playerFactory;
        private readonly AsteroidsSpawner _asteroidsSpawner;

        private GameStatesFactory(UIStateMachine uiStateMachine, PlayerFactory playerFactory, AsteroidsSpawner asteroidsSpawner)
        {
            _uiStateMachine = uiStateMachine;
            _playerFactory = playerFactory;
            _asteroidsSpawner = asteroidsSpawner;
        }

        public IGameState CreateInitState(GameStateMachine stateMachine)
        {
            return new InitState(stateMachine, _uiStateMachine);
        }

        public IGameState CreateGameState(GameStateMachine stateMachine)
        {
            return new GameState(stateMachine, _uiStateMachine, _playerFactory, _asteroidsSpawner);
        }

        public IGameState CreateGameOverState(GameStateMachine stateMachine)
        {
            return new GameOverState(stateMachine);
        }
    }
}