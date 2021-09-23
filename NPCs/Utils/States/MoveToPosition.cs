using Microsoft.Xna.Framework;
using Terraria;

namespace ExxoAvalonOrigins.NPCs.Utils.States
{
    public class MoveToPosition : State
    {
        private const float DashNodeActivationRadius = 16f;
        private readonly float speed;
        private readonly float minSpeed;
        private readonly bool relativeToTarget;
        private readonly Vector2 position;
        private readonly Vector2 targetedPosition;

        public MoveToPosition(Vector2 position, float speed, float minSpeed, bool relativeToTarget = false)
        {
            this.position = position;
            this.speed = speed;
            this.minSpeed = minSpeed;
            this.relativeToTarget = relativeToTarget;
            targetedPosition = Vector2.Zero;
        }

        public MoveToPosition(Vector2 position, Vector2 targetedPosition, float speed, float minSpeed) : this(position, speed, minSpeed)
        {
            this.targetedPosition = targetedPosition;
        }

        protected override void Update()
        {
            npc.velocity = Vector2.Zero;
            Vector2 vectorToNode = position;

            if (relativeToTarget)
            {
                vectorToNode += target.Center;
                npc.velocity = target.velocity;
            }
            else if (targetedPosition != Vector2.Zero)
            {
                vectorToNode += targetedPosition;
            }

            vectorToNode -= npc.Center;
            npc.velocity += vectorToNode * speed;

            Vector2 unit = vectorToNode.SafeNormalize(Vector2.UnitX);
            npc.velocity += unit * minSpeed;

            if (vectorToNode.Length() < DashNodeActivationRadius)
            {
                Destroy();
            }
        }
    }
}
