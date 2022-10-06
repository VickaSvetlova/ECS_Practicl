using Unity.Entities;
using UnityEngine;

//[RequiresEntityConversion]
[AddComponentMenu("Custom Authoring/Leader Authoring")]
public class LeaderAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public GameObject FollowerObject;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        FollowerEntity followerEntity = FollowerObject.GetComponent<FollowerEntity>();

        if (followerEntity == null)
        {
            followerEntity = FollowerObject.AddComponent<FollowerEntity>();
        }

        followerEntity.entityToFollow = entity;
    }
}