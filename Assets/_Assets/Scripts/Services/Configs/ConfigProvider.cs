using UnityEngine;

namespace _Assets.Scripts.Services.Configs
{
    public class ConfigProvider : MonoBehaviour
    {
        [SerializeField] private UIConfig uiConfig;
        [SerializeField] private EntitiesConfig entitiesConfig;
        [SerializeField] private GameConfig gameConfig;
        public UIConfig UIConfig => uiConfig;
        public EntitiesConfig EntitiesConfig => entitiesConfig;
        public GameConfig GameConfig => gameConfig;
    }
}