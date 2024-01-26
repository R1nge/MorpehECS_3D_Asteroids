using _Assets.Scripts.Services.Spawners;
using _Assets.Scripts.Services.UIs.StateMachine;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class GameState : IGameState
    {
        private readonly UIStateMachine _uiStateMachine;
        private readonly PlayerSpawner _playerSpawner;
        private readonly AsteroidsSpawner _asteroidsSpawner;
        private readonly BulletSpawner _bulletSpawner;
        private readonly ScoreService _scoreService;
        private readonly PlayerLivesService _playerLivesService;

        public GameState(GameStateMachine stateMachine, UIStateMachine uiStateMachine, PlayerSpawner playerSpawner,AsteroidsSpawner asteroidsSpawner, BulletSpawner bulletSpawner, ScoreService scoreService, PlayerLivesService playerLivesService)
        {
            _uiStateMachine = uiStateMachine;
            _playerSpawner = playerSpawner;
            _asteroidsSpawner = asteroidsSpawner;
            _bulletSpawner = bulletSpawner;
            _scoreService = scoreService;
            _playerLivesService = playerLivesService;
        }

        public void Enter()
        {
            _playerLivesService.Reset();
            _uiStateMachine.SwitchState(UIStateType.InGame);
            _playerSpawner.Spawn();
            _asteroidsSpawner.Spawn();
        }

        public void Exit()
        {
            _playerSpawner.Destroy();
            _asteroidsSpawner.Destroy();
            _bulletSpawner.Destroy();
            _scoreService.Reset();
        }
    }
}