using UnityEngine;

namespace _Assets.Scripts.Services.Configs
{
    [CreateAssetMenu(fileName = "Game Config", menuName = "Configs/Game Config")]
    public class GameConfig : ScriptableObject
    {
        public int maxLives;
    }
}