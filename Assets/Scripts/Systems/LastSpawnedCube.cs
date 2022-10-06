using Unity.Entities;

[GenerateAuthoringComponent]
public struct LastSpawnedCube : IComponentData
{
    public Entity Value;
}