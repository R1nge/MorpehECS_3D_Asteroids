using System;
using Unity.VisualScripting;
using UnityEngine;

namespace _Assets.Scripts.Services
{
    public class ScoreService
    {
        private int _score;
        public int Score => _score;
        public event Action<int> OnScoreChanged; 

        public void AddPoints(int points)
        {
            if (points <= 0)
            {
                Debug.LogWarning($"Trying to add {points} points");
                return;
            }

            _score += points;
            OnScoreChanged?.Invoke(_score);
            Debug.Log($"Score: {_score}");
        }
    }
}