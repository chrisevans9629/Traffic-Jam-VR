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
    private Rigidbody rigidbody;

    public GameObject Hand;

    public SteamVR_Action_Boolean DragAction;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


   // private Vector3 oldPosition;
    //private Quaternion oldRotation;
    //private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers) & (~Hand.AttachmentFlags.VelocityMovement);
    //private SteamVR_Action_Boolean drag = SteamVR_Input.GetBooleanAction("drag");
    //private SteamVR_Action_Boolean drag1 = SteamVR_Input.GetBooleanAction("drag1");
    private void HandHoverUpdate(Hand hand)
    {
        if (DragAction.state)
        {
            var joint = Hand.GetComponentInChildren<CharacterJoint>();
            if (joint == null)
            {
                joint = Instantiate(JointPrefab, Hand.transform.position, Hand.transform.rotation, Hand.transform);
                joint.connectedBody = rigidbody;
            }

        }
    }

    void Update()
    {
        if (!DragAction.state && Hand != null)
        {
            var joint = Hand.gameObject.GetComponentInChildren<CharacterJoint>();
            if (joint != null)
            {
                Destroy(joint.gameObject);
            }
        }

        //if (!drag1.state && rightHand != null)
        //{
        //    var joint = rightHand.gameObject.GetComponentInChildren<CharacterJoint>();
        //    if (joint != null)
        //    {
        //        Destroy(joint.gameObject);
        //    }
        //}
    }
}
