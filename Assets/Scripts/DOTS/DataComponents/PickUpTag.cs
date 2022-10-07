using Unity.Burst;
using Unity.Entities;

[GenerateAuthoringComponent]
[BurstCompile]
public struct PickUpTag : IComponentData
{
    public bool isDead;
}