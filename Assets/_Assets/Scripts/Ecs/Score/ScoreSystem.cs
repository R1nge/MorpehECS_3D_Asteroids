using _Assets.Scripts.Ecs.Requests;
using _Assets.Scripts.Services;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Ecs.Score
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(ScoreSystem))]
    public class ScoreSystem : UpdateSystem
    {
        [Inject] private ScoreService _scoreService;
        private Request<AddPointsRequest> _addPointsRequest;

        public override void OnAwake() => _addPointsRequest = World.GetRequest<AddPointsRequest>();

        public override void OnUpdate(float deltaTime)
        {
            foreach (var request in _addPointsRequest.Consume())
            {
                AddPoints(request.Points);
            }
        }

        private void AddPoints(int points) => _scoreService.AddPoints(points);
    }
}