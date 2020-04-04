using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
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

    private CharacterJoint joint;
    private void HandHoverUpdate(Hand hand)
    {
        if (DragAction.state)
        {
            
            if (joint == null)
            {
                joint = Instantiate(JointPrefab, Hand.transform.position, Hand.transform.rotation);
                joint.GetComponent<HandRigidBody>().Hand = Hand;
                joint.connectedBody = rigidbody;
            }

        }
    }

    void Update()
    {
        if (!DragAction.state)
        {
            if (joint != null)
            {
                Destroy(joint.gameObject);
                joint = null;
            }
        }
    }
}
