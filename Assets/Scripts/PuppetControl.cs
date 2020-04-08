using Assets.Scripts;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class PuppetControl : MonoBehaviour
{
    private Interactable interactable;

    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    void HandHoverUpdate(Hand hand)
    {
        var r = hand.IsGrabEnding(gameObject);
        if (r)
        {
            var joints = GameObject.FindGameObjectsWithTag("PlankJoint");
            foreach (var joint in joints)
            {
                var hrb = joint.GetComponent<FollowControl>();
                if (hrb.ObjectToFollow == gameObject)
                {
                    Destroy(hrb.gameObject);
                }
            }
            hand.HoverUnlock(interactable);
            Destroy(gameObject);
        }
    }
}