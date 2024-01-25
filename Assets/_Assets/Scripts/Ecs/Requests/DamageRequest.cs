using Scellecs.Morpeh;

namespace _Assets.Scripts.Ecs.Requests
{
    public struct DamageRequest : IRequestData
    {
        public EntityId targetEntityId;
    }
}