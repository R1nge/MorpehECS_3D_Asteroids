using _Assets.Scripts.Services.Configs;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services.UIs
{
    public class UIFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly ConfigProvider _configProvider;

        private UIFactory(IObjectResolver objectResolver, ConfigProvider configProvider)
        {
            _objectResolver = objectResolver;
            _configProvider = configProvider;
        }
        
        public MainMenuUI CreateMainMenuUI() => _objectResolver.Instantiate(_configProvider.UIConfig.MainMenuUI);
        
        public InGameUI CreateInGameUI() => _objectResolver.Instantiate(_configProvider.UIConfig.InGameUI);
        
        public GameOverUI CreateGameOverUI() => _objectResolver.Instantiate(_configProvider.UIConfig.GameOverUI);
    }
}