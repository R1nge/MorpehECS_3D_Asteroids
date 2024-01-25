using Scellecs.Morpeh;

namespace _Assets.Scripts.Ecs.Events
{
    public struct DamagedEvent : IEventData
    {
        public EntityId targetEntityId;
        public int damage;
    }
}