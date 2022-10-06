using Unity.Burst;
using Unity.Entities;
using Unity.Physics;

[BurstCompile]
struct TriggerJob : ITriggerEventsJob
{
    [Unity.Collections.ReadOnly] public ComponentDataFromEntity<PickUpTag> allPickups;
    public ComponentDataFromEntity<PlayerTag> allPlayer;
    public EntityCommandBuffer ecb;

    public void Execute(TriggerEvent triggerEvent)
    {
        Entity entityA = triggerEvent.EntityA;
        Entity entityB = triggerEvent.EntityB;

        if (allPickups.HasComponent(entityA) && allPickups.HasComponent(entityB)) return;
        if (allPickups.HasComponent(entityA) && allPlayer.HasComponent(entityB))
        {
            ecb.DestroyEntity(entityA);
        }
        else if (allPickups.HasComponent(entityA) && allPlayer.HasComponent(entityA))
        {
            ecb.DestroyEntity(entityB);
        }
    }
}