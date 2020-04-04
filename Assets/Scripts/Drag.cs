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

    private Hand leftHand;

    private Hand rightHand;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        interactable = GetComponent<Interactable>();
        leftHand = Player.instance.leftHand;
        rightHand = Player.instance.rightHand;
    }


   // private Vector3 oldPosition;
    //private Quaternion oldRotation;
    //private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers) & (~Hand.AttachmentFlags.VelocityMovement);
    private SteamVR_Action_Boolean drag = SteamVR_Input.GetBooleanAction("drag");
    private SteamVR_Action_Boolean drag1 = SteamVR_Input.GetBooleanAction("drag1");
    private void HandHoverUpdate(Hand hand)
    {
        if (drag.state || drag1.state)
        {
            var joint = hand.GetComponentInChildren<CharacterJoint>();
            if (joint == null)
            {
                joint = Instantiate(JointPrefab, hand.transform.position, hand.transform.rotation, hand.transform);
                joint.connectedBody = rigidbody;
            }

        }
    }

    void Update()
    {
        if (!drag.state && leftHand != null)
        {
            var joint = leftHand.gameObject.GetComponentInChildren<CharacterJoint>();
            if (joint != null)
            {
                Destroy(joint.gameObject);
            }
        }

        if (!drag1.state && rightHand != null)
        {
            var joint = rightHand.gameObject.GetComponentInChildren<CharacterJoint>();
            if (joint != null)
            {
                Destroy(joint.gameObject);
            }
        }
    }
}
