using UnityEngine;

namespace _Assets.Scripts.Services
{
    public class ScoreService
    {
        private int _score;
        public int Score => _score;

        public void AddPoints(int points)
        {
            if (points <= 0)
            {
                Debug.LogWarning($"Trying to add {points} points");
                return;
            }

            _score += points;
            Debug.Log($"Score: {_score}");
        }
    }
}