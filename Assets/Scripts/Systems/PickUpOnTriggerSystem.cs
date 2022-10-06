using Unity.Entities;
using Unity.Physics;
using Unity.Physics.Systems;
using UnityEngine;

public partial class PickUpOnTriggerSystem : SystemBase
{
    private EndInitializationEntityCommandBufferSystem _endEcbSystem;
    private StepPhysicsWorld _stepPhysicsWorld;

    protected override void OnCreate()
    {
        base.OnCreate();
        _endEcbSystem = World.GetOrCreateSystem<EndInitializationEntityCommandBufferSystem>();
        _stepPhysicsWorld = World.GetOrCreateSystem<StepPhysicsWorld>();
    }

    protected override void OnUpdate()
    {
        var triggerJiob = new TriggerJob
        {
            allPickups = GetComponentDataFromEntity<PickUpTag>(true),
            allPlayer = GetComponentDataFromEntity<PlayerTag>(),
            ecb = _endEcbSystem.CreateCommandBuffer()
        };
        Dependency = triggerJiob.Schedule(_stepPhysicsWorld.Simulation, Dependency);
        _endEcbSystem.AddJobHandleForProducer(Dependency);
    }
}