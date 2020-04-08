using UnityEngine;
using Valve.VR.InteractionSystem;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class FollowControl : MonoBehaviour
    {
        public GameObject ObjectToFollow;
        private Rigidbody rigidbody;
        public float Speed = 4.0f;
        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if(ObjectToFollow == null)
                return;
            var targetPosition = ObjectToFollow.gameObject.transform.position;

            var currentPosition = transform.position;

            var force = (targetPosition - currentPosition) * Speed;

            rigidbody.velocity = force;

            //rigidbody.AddForce(force, ForceMode.VelocityChange);

            //rigidbody.velocity = (targetPosition - currentPosition) / 2.0f;
        }


    }
}