using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
[GenerateAuthoringComponent]
[BurstCompile]
public struct RotationSpeedData : IComponentData
{
    public float Speed;
}