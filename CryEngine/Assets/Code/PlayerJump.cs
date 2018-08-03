using System;
using CryEngine;

namespace CryEngine.Game
{
	[EntityComponent(Guid="aafb8a78-8fd8-0b6c-0595-68d6a98aa9a1")]
	public class PlayerJump : EntityComponent
	{
        private void PrepareRigidbody()
        {
            var physicsEntity = Entity.Physics;

            if (physicsEntity ==  null)
            {
                return;
            }

            var parameters = new LivingPhysicalizeParams();
            var playerDimensions = parameters.PlayerDimensions;
            parameters.Mass = 90f;
            playerDimensions.PivotHeight = 1f;
            Entity.Physics.Physicalize(parameters);
        }

        protected override void OnGameplayStart()
        {
            base.OnGameplayStart();
            PrepareRigidbody();
        }

        private void Jump()
        {
            float jumpForce = 10f;
            bool grounded = Entity.Physics.GetStatus<LivingStatus>().IsFlying;

            if (Input.KeyDown(KeyId.Space) && !grounded)
            {
                Entity.Physics.Jump(new Vector3(0f, 0f, jumpForce));
            }
        }

        protected override void OnUpdate(float frameTime)
        {
            base.OnUpdate(frameTime);
            Jump();
        }
    }
}