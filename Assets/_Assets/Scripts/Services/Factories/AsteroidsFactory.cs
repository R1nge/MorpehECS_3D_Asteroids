using _Assets.Scripts.Services.Configs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services.Factories
{
    public class AsteroidsFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly ConfigProvider _configProvider;

        private AsteroidsFactory(IObjectResolver objectResolver, ConfigProvider configProvider)
        {
            _objectResolver = objectResolver;
            _configProvider = configProvider;
        }
        
        public GameObject CreateSmallAsteroid() => _objectResolver.Instantiate(_configProvider.EntitiesConfig.SmallAsteroid);

        public GameObject CreateMediumAsteroid() => _objectResolver.Instantiate(_configProvider.EntitiesConfig.MediumAsteroid);

        public GameObject CreateLargeAsteroid() => _objectResolver.Instantiate(_configProvider.EntitiesConfig.LargeAsteroid);
    }
}