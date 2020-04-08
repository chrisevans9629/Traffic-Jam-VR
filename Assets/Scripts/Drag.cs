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
    //public Grabber Hand;
    //public SteamVR_Action_Boolean DragActions;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    //private CharacterJoint joint;
    private void HandHoverUpdate(Hand hand)
    {
        var grab = hand.GetGrabStarting();
        if (grab != GrabTypes.None)
        {
            Debug.Log("Grabbed!", this);
            var ball = Instantiate(BallPrefab, transform.position, transform.rotation);
            hand.AttachObject(ball, GrabTypes.Grip);
            hand.HoverLock(ball.GetComponent<Interactable>());

            var joint = Instantiate(JointPrefab, transform.position,transform.rotation);
            joint.GetComponent<FollowControl>().ObjectToFollow = ball;
            joint.connectedBody = rigidbody;
        }
    }

    //void Update()
    //{
    //    var left
    //    if ()
    //    {
    //        if (joint != null)
    //        {
    //            Destroy(joint.gameObject);
    //            joint = null;
    //        }
    //        renderer.material.color = normalColor;

    //    }
    //}
}