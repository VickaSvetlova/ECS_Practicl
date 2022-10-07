using Unity.Entities;

[GenerateAuthoringComponent]
public struct SamplePrefab : IComponentData
{
    public Entity Value;
}