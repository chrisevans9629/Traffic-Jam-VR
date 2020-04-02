using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Drag : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.instance.leftHand.grabGripAction.state)
        {
            Debug.Log("Left Grip!!");
        }
        if (Player.instance.rightHand.grabGripAction.state)
        {
            Debug.Log("Left Grip!!");
        }
    }
}
