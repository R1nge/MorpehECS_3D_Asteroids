using UnityEngine;

namespace _Assets.Scripts.Services.Configs
{
    public class ConfigProvider : MonoBehaviour
    {
        [SerializeField] private UIConfig uiConfig;
        public UIConfig UIConfig => uiConfig;
    }
}