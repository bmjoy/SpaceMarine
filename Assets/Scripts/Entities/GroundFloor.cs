﻿namespace SpaceMarine
{
    public class GroundFloor : BaseEntity
    {
        protected override void OnCollisionEnterPlayer()
        {
            MyPlayer.Attributes.IsGrounded = true;
        }

        protected override void OnCollisionExitPlayer()
        {
            MyPlayer.Attributes.IsGrounded = false;
        }
    }
}