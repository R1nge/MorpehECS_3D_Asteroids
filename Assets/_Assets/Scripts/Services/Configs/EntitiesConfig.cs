using UnityEngine;

namespace _Assets.Scripts.Services.Configs
{
    [CreateAssetMenu(fileName = "Entities Config", menuName = "Configs/Entities")]
    public class EntitiesConfig : ScriptableObject
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject largeAsteroid, mediumAsteroid, smallAsteroid;
        [SerializeField] private GameObject bullet;
        
        public GameObject Player => player;
        public GameObject LargeAsteroid => largeAsteroid;
        public GameObject MediumAsteroid => mediumAsteroid;
        public GameObject SmallAsteroid => smallAsteroid;
        public GameObject Bullet => bullet;
    }
}