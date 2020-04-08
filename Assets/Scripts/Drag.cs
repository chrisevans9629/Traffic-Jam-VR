using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;


[RequireComponent(typeof(Rigidbody))]
public class Drag : MonoBehaviour
{
    public CharacterJoint JointPrefab;
    private Rigidbody rigidbody;

    public GameObject BallPrefab;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void HandHoverUpdate(Hand hand)
    {
        var grab = hand.GetGrabStarting();
        if (grab != GrabTypes.None)
        {
            Debug.Log("Grabbed!", this);
            var ball = Instantiate(BallPrefab, hand.transform.position, hand.transform.rotation);
            hand.AttachObject(ball, GrabTypes.Grip);
            hand.HoverLock(ball.GetComponent<Interactable>());

            var joint = Instantiate(JointPrefab, hand.transform.position, hand.transform.rotation);
            var follow = joint.GetComponent<FollowControl>();
            follow.ObjectToFollow = ball;
            follow.Offset = joint.transform.position - ball.transform.position;
            joint.connectedBody = rigidbody;
        }
    }

}