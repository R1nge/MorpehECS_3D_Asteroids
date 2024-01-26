using Scellecs.Morpeh;

namespace _Assets.Scripts.Ecs.Events
{
    public struct DamagedEvent : IEventData
    {
        public EntityId TargetEntityId;
        public bool IsPlayer;
    }
}