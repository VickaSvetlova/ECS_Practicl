using Unity.Entities;
using Unity.Physics;
using Unity.Mathematics;
using UnityEngine;

[AlwaysSynchronizeSystem]
public partial class MovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        float2 curInput = new float2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Entities.ForEach((ref PhysicsVelocity velocity, in SpeedData speedData) =>
        {
            float2 newVel = velocity.Linear.xz;
            newVel += curInput * speedData.Speed * deltaTime;
            velocity.Linear.xz = newVel;
        }).Run();
    }
}