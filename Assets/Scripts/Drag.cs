using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Rigidbody))]
public class Drag : MonoBehaviour
{
    public CharacterJoint JointPrefab;
    private Interactable interactable;

    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        interactable = GetComponent<Interactable>();
    }


   // private Vector3 oldPosition;
    //private Quaternion oldRotation;
    //private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers) & (~Hand.AttachmentFlags.VelocityMovement);
    private SteamVR_Action_Boolean drag = SteamVR_Input.GetBooleanAction("drag");
    private void HandHoverUpdate(Hand hand)
    {
        
        //GrabTypes startingGrabType = hand.GetGrabStarting();
        //bool isGrabEnding = hand.IsGrabEnding(this.gameObject);
        this.hand = hand;
        if (drag.state)
        {
            // Save our position/rotation so that we can restore it when we detach
            //oldPosition = transform.position;
            //oldRotation = transform.rotation;

            // Call this to continue receiving HandHoverUpdate messages,
            // and prevent the hand from hovering over anything else
           // hand.HoverLock(interactable);

            var joint = hand.GetComponentInChildren<CharacterJoint>();
            if (joint == null)
            {
                joint = Instantiate(JointPrefab, hand.transform.position, hand.transform.rotation, hand.transform);
                joint.connectedBody = rigidbody;
            }


            //joint.connectedBody =
            // Attach this object to the hand
            //hand.AttachObject(gameObject, startingGrabType, attachmentFlags);
        }
        //else if (isGrabEnding)
        //{
        //    // Detach this object from the hand
        //    //hand.DetachObject(gameObject);

        //    // Call this to undo HoverLock
        //    //hand.HoverUnlock(interactable);
            
        //    // Restore position/rotation
        //    //transform.position = oldPosition;
        //    //transform.rotation = oldRotation;
        //}
    }

    private Hand hand;
    void Update()
    {
        if (!drag.state && hand != null)
        {
            var joint = hand.gameObject.GetComponentInChildren<CharacterJoint>();
            if (joint != null)
            {
                Destroy(joint.gameObject);
            }

            hand = null;
        }
    }
}
