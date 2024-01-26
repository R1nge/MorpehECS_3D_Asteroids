using Scellecs.Morpeh;

namespace _Assets.Scripts.Ecs.Requests
{
    public struct DamageRequest : IRequestData
    {
        public EntityId TargetEntityId;
        public int Damage;
        public bool IsPlayer;
    }
}