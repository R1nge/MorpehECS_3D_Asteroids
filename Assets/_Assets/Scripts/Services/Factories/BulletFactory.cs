using _Assets.Scripts.Services.Configs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services.Factories
{
    public class BulletFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly ConfigProvider _configProvider;

        private BulletFactory(IObjectResolver objectResolver, ConfigProvider configProvider)
        {
            _objectResolver = objectResolver;
            _configProvider = configProvider;
        }
        
        public GameObject Create(Vector3 position)
        {
            return _objectResolver.Instantiate(_configProvider.EntitiesConfig.Bullet, position, Quaternion.identity);
        }
    }
}