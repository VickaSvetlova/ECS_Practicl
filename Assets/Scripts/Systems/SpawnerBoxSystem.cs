using Buffer;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[UpdateBefore(typeof(TransformSystemGroup))]
public partial class SpawnerBoxSystem : SystemBase
{
    private Entity _prefabCube;
    private Entity _cubeSpawner;
    private BeginInitializationEntityCommandBufferSystem _ecbSystem;
    public int CountX = 100;
    public int CountY = 100;

    protected override void OnStartRunning()
    {
        base.OnCreate();
        Application.targetFrameRate = 30;
        _prefabCube = GetSingleton<SamplePrefab>().Value;
        _ecbSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();

        _cubeSpawner = GetSingletonEntity<LastSpawnedCube>();
        EntityManager.AddBuffer<SpawnedBoxBufferElement>(_cubeSpawner);
        SpawnBoxFromNoice();
    }

    protected override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBoxFromNoice();
        }
    }

    private void SpawnBoxFromNoice()
    {
        for (int x = 0; x < CountX; x++)
        {
            for (int y = 0; y < CountY; y++)
            {
                var ecb = _ecbSystem.CreateCommandBuffer();
                var instance = ecb.Instantiate(_prefabCube);
                var position = (new float3(x * 1.3f, noise.cnoise(new float2(x, y) * 0.21f) * 2, y * 1.3f));
                ecb.SetComponent(instance, new Translation { Value = position });

                ecb.AppendToBuffer(_cubeSpawner, new SpawnedBoxBufferElement { Value = instance });
            }
        }
    }
}