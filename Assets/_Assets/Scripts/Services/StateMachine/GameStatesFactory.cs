using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.StateMachine.States;
using _Assets.Scripts.Services.UIs.StateMachine;

namespace _Assets.Scripts.Services.StateMachine
{
    public class GameStatesFactory
    {
        private readonly UIStateMachine _uiStateMachine;
        private readonly PlayerFactory _playerFactory;
        private readonly AsteroidsFactory _asteroidsFactory;

        private GameStatesFactory(UIStateMachine uiStateMachine, PlayerFactory playerFactory, AsteroidsFactory asteroidsFactory)
        {
            _uiStateMachine = uiStateMachine;
            _playerFactory = playerFactory;
            _asteroidsFactory = asteroidsFactory;
        }
        
        public IGameState CreateInitState(GameStateMachine stateMachine)
        {
            return new InitState(stateMachine, _uiStateMachine);
        }

        public IGameState CreateGameState(GameStateMachine stateMachine)
        {
            return new GameState(stateMachine, _uiStateMachine, _playerFactory, _asteroidsFactory);
        }

        public IGameState CreateGameOverState(GameStateMachine stateMachine)
        {
            return new GameOverState(stateMachine);
        }
    }
}