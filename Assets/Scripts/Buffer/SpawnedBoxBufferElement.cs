using Unity.Entities;

namespace Buffer
{
    [InternalBufferCapacity(8)]
    public struct SpawnedBoxBufferElement: IBufferElementData
    {
        public Entity Value;
    }
}