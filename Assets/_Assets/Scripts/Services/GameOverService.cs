using _Assets.Scripts.Services.StateMachine;
using VContainer.Unity;

namespace _Assets.Scripts.Services
{
    public class GameOverService : IInitializable
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly PlayerLivesService _playerLivesService;

        private GameOverService(GameStateMachine gameStateMachine, PlayerLivesService playerLivesService)
        {
            _gameStateMachine = gameStateMachine;
            _playerLivesService = playerLivesService;
        }
        
        public void Initialize() => _playerLivesService.OnLivesChanged += GameOver;

        private void GameOver(int lives)
        {
            if (lives <= 0)
            {
                _gameStateMachine.SwitchState(GameStateType.GameOver);
            }
        }
    }
}