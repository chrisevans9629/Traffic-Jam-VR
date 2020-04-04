using UnityEngine;
using Valve.VR.InteractionSystem;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class HandRigidBody : MonoBehaviour
    {
        public Hand Hand;
        private Rigidbody rigidbody;
        public float Speed = 4.0f;
        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            var targetPosition = Hand.gameObject.transform.position;

            var currentPosition = transform.position;

            var force = (targetPosition - currentPosition) * Speed;

            rigidbody.velocity = force;

            //rigidbody.AddForce(force, ForceMode.VelocityChange);

            //rigidbody.velocity = (targetPosition - currentPosition) / 2.0f;
        }


    }
}