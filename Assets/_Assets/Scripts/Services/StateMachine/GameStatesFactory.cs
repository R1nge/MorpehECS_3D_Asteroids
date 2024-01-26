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
        private readonly BulletSpawner _bulletSpawner;
        private readonly ScoreService _scoreService;
        private readonly PlayerLivesService _playerLivesService;

        private GameStatesFactory(UIStateMachine uiStateMachine, PlayerSpawner playerSpawner, AsteroidsSpawner asteroidsSpawner, BulletSpawner bulletSpawner, ScoreService scoreService, PlayerLivesService playerLivesService)
        {
            _uiStateMachine = uiStateMachine;
            _playerSpawner = playerSpawner;
            _asteroidsSpawner = asteroidsSpawner;
            _bulletSpawner = bulletSpawner;
            _scoreService = scoreService;
            _playerLivesService = playerLivesService;
        }

        public IGameState CreateInitState(GameStateMachine stateMachine)
        {
            return new InitState(stateMachine, _uiStateMachine);
        }

        public IGameState CreateGameState(GameStateMachine stateMachine)
        {
            return new GameState(stateMachine, _uiStateMachine, _playerSpawner, _asteroidsSpawner, _bulletSpawner, _scoreService, _playerLivesService);
        }

        public IGameState CreateGameOverState(GameStateMachine stateMachine)
        {
            return new GameOverState(stateMachine, _uiStateMachine);
        }
    }
}