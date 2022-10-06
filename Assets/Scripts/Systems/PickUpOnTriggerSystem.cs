using Unity.Entities;
using Unity.Physics;
using Unity.Physics.Systems;
using Unity.Transforms;

[UpdateBefore(typeof(TransformSystemGroup))]
public partial class PickUpOnTriggerSystem : SystemBase
{
    private EndSimulationEntityCommandBufferSystem _endEcbSystem;
    private StepPhysicsWorld _stepPhysicsWorld;

    protected override void OnCreate()
    {
        base.OnCreate();
        _endEcbSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        _stepPhysicsWorld = World.GetOrCreateSystem<StepPhysicsWorld>();
    }

    protected override void OnUpdate()
    {
        EntityCommandBuffer entityCommandBuffer = _endEcbSystem.CreateCommandBuffer();

        Entities.WithAll<PickUpTag>().ForEach((Entity entity, in PickUpTag pickUp) =>
             {
                 if (pickUp.isDead)
                 {
                     entityCommandBuffer.DestroyEntity(entity);
                 }
             }
         ).Schedule();

        // var triggerJob = new TriggerJob
        // {
        //     allPickups = GetComponentDataFromEntity<PickUpTag>(true),
        //     allPlayer = GetComponentDataFromEntity<PlayerTag>(),
        //     ecb = _endEcbSystem.CreateCommandBuffer()
        // };
        // Dependency = triggerJob.Schedule(_stepPhysicsWorld.Simulation, Dependency);
        
        _endEcbSystem.AddJobHandleForProducer(this.Dependency);
    }
}