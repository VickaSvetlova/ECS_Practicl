using Unity.Burst;
using Unity.Entities;

[GenerateAuthoringComponent]
[BurstCompile]
public struct RotationSpeedData : IComponentData
{
    public float Speed;
}