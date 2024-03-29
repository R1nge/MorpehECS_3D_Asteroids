﻿using _Assets.Scripts.Services;
using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.Spawners;
using _Assets.Scripts.Services.StateMachine;
using _Assets.Scripts.Services.UIs;
using _Assets.Scripts.Services.UIs.StateMachine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.CompositionRoot
{
    public class GameInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<ScoreService>(Lifetime.Singleton);
            
            builder.Register<UIStatesFactory>(Lifetime.Singleton);
            builder.Register<UIStateMachine>(Lifetime.Singleton);

            builder.Register<UIFactory>(Lifetime.Singleton);

            builder.Register<BulletSpawner>(Lifetime.Singleton);
            builder.Register<BulletFactory>(Lifetime.Singleton);

            builder.Register<PlayerLivesService>(Lifetime.Singleton);

            builder.Register<PlayerFactory>(Lifetime.Singleton);
            builder.Register<PlayerSpawner>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            
            builder.Register<AsteroidsFactory>(Lifetime.Singleton);
            builder.Register<AsteroidsSpawner>(Lifetime.Singleton);

            builder.Register<GameStatesFactory>(Lifetime.Singleton);
            builder.Register<GameStateMachine>(Lifetime.Singleton);

            builder.Register<GameOverService>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        }
    }
}