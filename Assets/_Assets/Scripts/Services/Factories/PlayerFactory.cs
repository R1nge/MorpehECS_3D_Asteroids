using UnityEngine;

namespace _Assets.Scripts.Services.Factories
{
    public class PlayerFactory : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab;

        public GameObject Create() => Instantiate(playerPrefab);
    }
}