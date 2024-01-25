using _Assets.Scripts.Services.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace _Assets.Scripts.Services.UIs
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private Button restart, mainMenu;
        [Inject] private GameStateMachine _gameStateMachine;

        private void Start()
        {
            restart.onClick.AddListener(Restart);
            mainMenu.onClick.AddListener(MainMenu);
        }

        private void Restart() => _gameStateMachine.SwitchState(GameStateType.Game);

        private void MainMenu() => _gameStateMachine.SwitchState(GameStateType.Init);

        private void OnDestroy()
        {
            restart.onClick.RemoveAllListeners();
            mainMenu.onClick.RemoveAllListeners();
        }
    }
}