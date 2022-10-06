using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[AlwaysSynchronizeSystem]
public partial class RotationSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        Entities.ForEach((ref Rotation rotation, in RotationSpeedData rotationData) =>
        {
            rotation.Value = math.mul(rotation.Value, quaternion.RotateX(math.radians(rotationData.Speed * deltaTime)));
            rotation.Value = math.mul(rotation.Value, quaternion.RotateY(math.radians(rotationData.Speed * deltaTime)));
            rotation.Value = math.mul(rotation.Value, quaternion.RotateZ(math.radians(rotationData.Speed * deltaTime)));

        }).Run();
    }
}