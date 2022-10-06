using Unity.Burst;
using Unity.Entities;

[GenerateAuthoringComponent]
[BurstCompile]
public struct SpeedData : IComponentData
{
    public float Speed;
}