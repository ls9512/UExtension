using UnityEngine;

namespace Aya.Extension
{
    public static class Rigidbody2DExtension
    {
        #region Clear

        public static void ClearMomentum(this Rigidbody2D rigidbody)
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.angularVelocity = 0f;
        }

        #endregion

        #region Position

        #region Set

        public static void SetPositionX(this Rigidbody2D rigidbody, float x)
        {
            var position = rigidbody.position;
            position.x = x;
            rigidbody.position = position;
        }

        public static void SetPositionY(this Rigidbody2D rigidbody, float y)
        {
            var position = rigidbody.position;
            position.y = y;
            rigidbody.position = position;
        }

        #endregion

        #region Get

        public static float GetPositionX(this Rigidbody2D rigidbody)
        {
            return rigidbody.position.x;
        }

        public static float GetPositionY(this Rigidbody2D rigidbody)
        {
            return rigidbody.position.y;
        }

        #endregion

        #endregion

        #region Velocity

        #region Set

        public static void SetVelocityX(this Rigidbody2D rigidbody, float x)
        {
            var velocity = rigidbody.velocity;
            velocity.x = x;
            rigidbody.velocity = velocity;
        }

        public static void SetVelocityY(this Rigidbody2D rigidbody, float y)
        {
            var velocity = rigidbody.velocity;
            velocity.y = y;
            rigidbody.velocity = velocity;
        }

        #endregion

        #region Get

        public static float GetVelocityX(this Rigidbody2D rigidbody)
        {
            return rigidbody.velocity.x;
        }

        public static float GetVelocityY(this Rigidbody2D rigidbody)
        {
            return rigidbody.velocity.y;
        }

        #endregion

        #region Add

        public static void AddVelocityX(this Rigidbody2D rigidbody, float x)
        {
            var velocity = rigidbody.velocity;
            velocity.x += x;
            rigidbody.velocity = velocity;
        }

        public static void AddVelocityY(this Rigidbody2D rigidbody, float y)
        {
            var velocity = rigidbody.velocity;
            velocity.y += y;
            rigidbody.velocity = velocity;
        }

        #endregion

        #endregion
    }
}

