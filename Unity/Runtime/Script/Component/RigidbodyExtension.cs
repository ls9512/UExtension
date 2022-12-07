using UnityEngine;

namespace Aya.Extension
{
    public static class RigidbodyExtension
    {
        #region Clear

        public static void ClearMomentum(this Rigidbody rigidbody)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }

        #endregion

        #region Position

        #region Set

        public static void SetPositionX(this Rigidbody rigidbody, float x)
        {
            var position = rigidbody.position;
            position.x = x;
            rigidbody.position = position;
        }

        public static void SetPositionY(this Rigidbody rigidbody, float y)
        {
            var position = rigidbody.position;
            position.y = y;
        }

        public static void SetPositionZ(this Rigidbody rigidbody, float z)
        {
            var position = rigidbody.position;
            position.z = z;
            rigidbody.position = position;
        }

        #endregion

        #region Get

        public static float GetPositionX(this Rigidbody rigidbody)
        {
            return rigidbody.position.x;
        }

        public static float GetPositionY(this Rigidbody rigidbody)
        {
            return rigidbody.position.y;
        }

        public static float GetPositionZ(this Rigidbody rigidbody)
        {
            return rigidbody.position.z;
        }

        #endregion

        #endregion

        #region Rotation

        #region Get

        public static float GetRotationX(this Rigidbody rigidbody)
        {
            return rigidbody.rotation.x;
        }

        public static float GetRotationY(this Transform rigidbody)
        {
            return rigidbody.rotation.y;
        }

        public static float GetRotationZ(this Rigidbody rigidbody)
        {
            return rigidbody.rotation.z;
        }

        public static float GetRotationW(this Rigidbody rigidbody)
        {
            return rigidbody.rotation.w;
        }

        #endregion

        #region Set

        public static void SetRotationX(this Rigidbody rigidbody, float x)
        {
            var rotation = rigidbody.rotation;
            rotation.x = x;
            rigidbody.rotation = rotation;
        }

        public static void SetRotationY(this Rigidbody rigidbody, float y)
        {
            var rotation = rigidbody.rotation;
            rotation.y = y;
            rigidbody.rotation = rotation;
        }

        public static void SetRotationZ(this Rigidbody rigidbody, float z)
        {
            var rotation = rigidbody.rotation;
            rotation.z = z;
            rigidbody.rotation = rotation;
        }

        public static void SetRotationW(this Rigidbody rigidbody, float w)
        {
            var rotation = rigidbody.rotation;
            rotation.w = w;
            rigidbody.rotation = rotation;
        }

        #endregion

        #endregion

        #region EulerAngles

        #region Set

        public static void SetEulerAnglesX(this Rigidbody transform, float x)
        {
            var eulerAngles = transform.rotation.eulerAngles;
            eulerAngles.x = x;
            transform.rotation = Quaternion.Euler(eulerAngles);
        }

        public static void SetEulerAnglesY(this Rigidbody transform, float y)
        {
            var eulerAngles = transform.rotation.eulerAngles;
            eulerAngles.y = y;
            transform.rotation = Quaternion.Euler(eulerAngles);
        }

        public static void SetEulerAnglesZ(this Rigidbody transform, float z)
        {
            var eulerAngles = transform.rotation.eulerAngles;
            eulerAngles.z = z;
            transform.rotation = Quaternion.Euler(eulerAngles);
        }

        #endregion

        #region Get

        public static float GetEulerAnglesX(this Rigidbody transform)
        {
            return transform.rotation.eulerAngles.x;
        }

        public static float GetEulerAnglesY(this Rigidbody transform)
        {
            return transform.rotation.eulerAngles.y;
        }

        public static float GetEulerAnglesZ(this Rigidbody transform)
        {
            return transform.rotation.eulerAngles.z;
        }

        #endregion

        #endregion

        #region Velocity

        #region Set

        public static void SetVelocityX(this Rigidbody rigidbody, float x)
        {
            var velocity = rigidbody.velocity;
            velocity.x = x;
            rigidbody.velocity = velocity;
        }

        public static void SetVelocityY(this Rigidbody rigidbody, float y)
        {
            var velocity = rigidbody.velocity;
            velocity.y = y;
            rigidbody.velocity = velocity;
        }

        public static void SetVelocityZ(this Rigidbody rigidbody, float z)
        {
            var velocity = rigidbody.velocity;
            velocity.z = z;
            rigidbody.velocity = velocity;
        }

        #endregion

        #region Get

        public static float GetVelocityX(this Rigidbody rigidbody)
        {
            return rigidbody.velocity.x;
        }

        public static float GetVelocityY(this Rigidbody rigidbody)
        {
            return rigidbody.velocity.y;
        }

        public static float GetVelocityZ(this Rigidbody rigidbody)
        {
            return rigidbody.velocity.z;
        }

        #endregion

        #region Add

        public static void AddVelocityX(this Rigidbody rigidbody, float x)
        {
            var velocity = rigidbody.velocity;
            velocity.x += x;
            rigidbody.velocity = velocity;
        }

        public static void AddVelocityY(this Rigidbody rigidbody, float y)
        {
            var velocity = rigidbody.velocity;
            velocity.y += y;
            rigidbody.velocity = velocity;
        }

        public static void AddVelocityZ(this Rigidbody rigidbody, float z)
        {
            var velocity = rigidbody.velocity;
            velocity.z += z;
            rigidbody.velocity = velocity;
        }

        #endregion

        #endregion

        #region AngularVelocity

        #region Set

        public static void SetAngularVelocityX(this Rigidbody rigidbody, float x)
        {
            var angularVelocity = rigidbody.angularVelocity;
            angularVelocity.x = x;
            rigidbody.angularVelocity = angularVelocity;
        }

        public static void SetAngularVelocityY(this Rigidbody rigidbody, float y)
        {
            var angularVelocity = rigidbody.angularVelocity;
            angularVelocity.y = y;
            rigidbody.angularVelocity = angularVelocity;
        }

        public static void SetAngularVelocityZ(this Rigidbody rigidbody, float z)
        {
            var angularVelocity = rigidbody.angularVelocity;
            angularVelocity.z = z;
            rigidbody.angularVelocity = angularVelocity;
        }

        #endregion

        #region Get

        public static float GetAngularVelocityX(this Rigidbody rigidbody)
        {
            return rigidbody.angularVelocity.x;
        }

        public static float GetAngularVelocityY(this Rigidbody rigidbody)
        {
            return rigidbody.angularVelocity.y;
        }

        public static float GetAngularVelocityZ(this Rigidbody rigidbody)
        {
            return rigidbody.angularVelocity.z;
        }

        #endregion

        #region Add

        public static void AddAngularVelocityX(this Rigidbody rigidbody, float x)
        {
            var angularVelocity = rigidbody.angularVelocity;
            angularVelocity.x += x;
            rigidbody.angularVelocity = angularVelocity;
        }

        public static void AddAngularVelocityY(this Rigidbody rigidbody, float y)
        {
            var angularVelocity = rigidbody.angularVelocity;
            angularVelocity.y += y;
            rigidbody.angularVelocity = angularVelocity;
        }

        public static void AddAngularVelocityZ(this Rigidbody rigidbody, float z)
        {
            var angularVelocity = rigidbody.angularVelocity;
            angularVelocity.z += z;
            rigidbody.angularVelocity = angularVelocity;
        }

        #endregion

        #endregion
    }
}

