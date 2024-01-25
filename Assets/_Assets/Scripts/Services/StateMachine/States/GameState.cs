using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.UIs.StateMachine;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class GameState : IGameState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly UIStateMachine _uiStateMachine;
        private readonly PlayerFactory _playerFactory;
        private readonly AsteroidsFactory _asteroidsFactory;

        public GameState(GameStateMachine stateMachine, UIStateMachine uiStateMachine, PlayerFactory playerFactory, AsteroidsFactory asteroidsFactory)
        {
            _stateMachine = stateMachine;
            _uiStateMachine = uiStateMachine;
            _playerFactory = playerFactory;
            _asteroidsFactory = asteroidsFactory;
        }

        public void Enter()
        {
            _uiStateMachine.SwitchState(UIStateType.InGame);
            _playerFactory.Create();
            //TODO: make a spawner for them
            _asteroidsFactory.CreateLargeAsteroid();
            _asteroidsFactory.CreateMediumAsteroid();
            _asteroidsFactory.CreateSmallAsteroid();
            //Since asteroids are spawned via factory, I can just pass it into them,
            //And call spawn method directly when one is destroyed
        }

        public void Exit()
        {
            //TODO: remove asteroids
            //TODO: destroy the player
        }
    }
}