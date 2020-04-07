using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;

public class GenerateTower : MonoBehaviour
{
    public int TowerFloors = 10;
    public float MassFloorRatio = 1;
    public Vector3 Spacing = Vector3.one;

    public GameObject Prefab;

    public Grabber leftHand;

    public Grabber rightHand;
    // Start is called before the first frame update
    void Start()
    {
        BuildTower();
    }

    public void BuildTower()
    {
        for (int floor = 0; floor < TowerFloors; floor++)
        {
            for (int plank = -1; plank < 2; plank++)
            {
                var box = CreatePlank();

                if (floor % 2 != 0)
                {
                    box.transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
                    box.transform.localPosition = new Vector3(plank * Spacing.x, floor * Spacing.y, 0);
                }
                else
                {
                    box.transform.localPosition = new Vector3(0, floor * Spacing.y, plank * Spacing.z);
                }

                box.GetComponent<Rigidbody>().mass /= (floor + 1) * MassFloorRatio;
            }
        }

        //StartCoroutine(EnablePhysics());
    }
    //public static IEnumerable<T> ToIEnumerable<T>(IEnumerator<T> enumerator)
    //{
    //    while (enumerator.MoveNext())
    //    {
    //        yield return enumerator.Current;
    //    }
    //}
    //private IEnumerator EnablePhysics()
    //{


    //    var transforms = transform.Cast<Transform>().GroupBy(p => p.transform.localPosition.y);
    //    foreach (var tr in transforms)
    //    {
    //        yield return new WaitForSeconds(0.1f);
    //        foreach (var transform1 in tr)
    //        {
    //            if (transform1 != null)
    //                transform1.GetComponent<Rigidbody>().isKinematic = false;
    //        }
    //    }
    //}

    private GameObject CreatePlank()
    {
        var box = Instantiate(Prefab, transform.position, Quaternion.identity, transform);
        var drags = box.GetComponents<Drag>();

        //box.GetComponent<Rigidbody>().isKinematic = true;

        drags[0].Hand = leftHand;
        drags[1].Hand = rightHand;
        return box;
    }

}
