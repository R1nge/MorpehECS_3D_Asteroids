using _Assets.Scripts.Services.UIs;
using UnityEngine;

namespace _Assets.Scripts.Services.Configs
{
    [CreateAssetMenu(fileName = "UI Config", menuName = "Configs/UI Config")]
    public class UIConfig : ScriptableObject
    {
        [SerializeField] private MainMenuUI mainMenuUI;
        [SerializeField] private InGameUI inGameUI;
        [SerializeField] private GameOverUI gameOverUI;
        public MainMenuUI MainMenuUI => mainMenuUI;
        public InGameUI InGameUI => inGameUI;
        public GameOverUI GameOverUI => gameOverUI;
    }
}