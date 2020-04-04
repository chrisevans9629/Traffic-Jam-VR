using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class GenerateTower : MonoBehaviour
{
    public int TowerFloors = 10;

    public Vector3 Spacing = Vector3.one;

    public GameObject Prefab;

    public Grabber leftHand;

    public Grabber rightHand;
    // Start is called before the first frame update
    void Start()
    {
        for (int floor = 0; floor < TowerFloors; floor++)
        {
            
            for (int plank = -1; plank < 2; plank++)
            {
                if (floor % 2 != 0)
                {
                    var box = Instantiate(Prefab, transform.position, Quaternion.identity, transform);

                    var drags = box.GetComponents<Drag>();
                    drags[0].Hand = leftHand;
                    drags[1].Hand = rightHand;

                    box.transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
                    box.transform.localPosition = new Vector3(plank * Spacing.x, floor * Spacing.y, 0);
                }
                else
                {
                    var box = Instantiate(Prefab, transform.position, Quaternion.identity, transform);
                    // box.transform.rotation = Quaternion.AngleAxis(90, Vector3.up);

                    var drags = box.GetComponents<Drag>();
                    drags[0].Hand = leftHand;
                    drags[1].Hand = rightHand;
                    box.transform.localPosition = new Vector3(0, floor * Spacing.y, plank * Spacing.z);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

       
    }
}
