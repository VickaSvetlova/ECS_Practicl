using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Systems;
using Unity.Transforms;

[UpdateAfter(typeof(EndFramePhysicsSystem))]
public partial class DeatchCollisionSystem : SystemBase
{
    [BurstCompile]
    struct DeatchCollisionSystemJob : ICollisionEventsJob
    {
        public void Execute(CollisionEvent collisionEvent)
        {
        }
    }

    protected override void OnUpdate()
    {
    }
}