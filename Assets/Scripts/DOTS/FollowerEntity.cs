using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class FollowerEntity : MonoBehaviour
{
    public Entity entityToFollow;
    public float3 offset = float3.zero;
    private EntityManager _manager;

    private void Awake()
    {
        _manager = World.DefaultGameObjectInjectionWorld.EntityManager;
    }

    private void LateUpdate()
    {
        Translation entPos = _manager.GetComponentData<Translation>(entityToFollow);
        transform.position = (entPos.Value + offset);
    }
}