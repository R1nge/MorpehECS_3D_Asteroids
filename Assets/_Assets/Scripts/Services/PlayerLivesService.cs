using System;

namespace _Assets.Scripts.Services
{
    public class PlayerLivesService
    {
        private int _lives;
        public int Lives
        {
            get => _lives;
            set => _lives = value;
        }

        public event Action<int> OnLivesChanged; 

        public void DecreaseLives(int amount)
        {
            Lives -= amount;
            OnLivesChanged?.Invoke(_lives);
        }

        public void Reset()
        {
            //TODO: max lives config
            Lives = 3;
        }
    }
}