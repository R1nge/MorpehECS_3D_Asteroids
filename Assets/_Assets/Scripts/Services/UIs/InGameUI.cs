using TMPro;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services.UIs
{
    public class InGameUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [Inject] private ScoreService _scoreService;

        private void Start()
        {
            _scoreService.OnScoreChanged += UpdateScore;
            UpdateScore(_scoreService.Score);
        }

        private void UpdateScore(int score) => scoreText.text = $"Score: {score}";

        private void OnDestroy() => _scoreService.OnScoreChanged -= UpdateScore;
    }
}