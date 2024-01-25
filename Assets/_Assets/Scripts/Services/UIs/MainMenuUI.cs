using _Assets.Scripts.Services.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace _Assets.Scripts.Services.UIs
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button playButton, quitButton;
        [Inject] private GameStateMachine _gameStateMachine;

        private void Awake()
        {
            playButton.onClick.AddListener(Play);
            quitButton.onClick.AddListener(Quit);
        }

        private void Play() => _gameStateMachine.SwitchState(GameStateType.Game);

        private void Quit() => Application.Quit();
    }
}