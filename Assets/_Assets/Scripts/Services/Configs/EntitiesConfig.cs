using UnityEngine;

namespace _Assets.Scripts.Services.Configs
{
    [CreateAssetMenu(fileName = "Entities Config", menuName = "Configs/Entities")]
    public class EntitiesConfig : ScriptableObject
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject bigAsteroid, mediumAsteroid, smallAsteroid;
        
        public GameObject Player => player;
        public GameObject BigAsteroid => bigAsteroid;
        public GameObject MediumAsteroid => mediumAsteroid;
        public GameObject SmallAsteroid => smallAsteroid;
    }
}