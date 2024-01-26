using TMPro;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services.UIs
{
    public class InGameUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI livesText;
        [Inject] private ScoreService _scoreService;
        [Inject] private PlayerLivesService _livesService;

        private void Start()
        {
            _scoreService.OnScoreChanged += UpdateScore;
            _livesService.OnLivesChanged += UpdateLives;
            UpdateScore(_scoreService.Score);
            UpdateLives(_livesService.Lives);
        }
        
        private void UpdateScore(int score) => scoreText.text = $"Score: {score}";
        private void UpdateLives(int lives) => livesText.text = $"Lives: {lives}";
        private void OnDestroy()
        {
            _scoreService.OnScoreChanged -= UpdateScore;
            _livesService.OnLivesChanged -= UpdateLives;
        }
    }
}