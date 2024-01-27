using System;
using _Assets.Scripts.Services.Configs;

namespace _Assets.Scripts.Services
{
    public class PlayerLivesService
    {
        private readonly ConfigProvider _configProvider;
        private PlayerLivesService(ConfigProvider configProvider) => _configProvider = configProvider;

        private int _lives;
        public int Lives
        {
            get => _lives;
            private set => _lives = value;
        }

        public event Action<int> OnLivesChanged; 

        public void DecreaseLives(int amount)
        {
            Lives -= amount;
            OnLivesChanged?.Invoke(_lives);
        }

        public void Reset() => Lives = _configProvider.GameConfig.maxLives;
    }
}