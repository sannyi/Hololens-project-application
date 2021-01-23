using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapAndPlace : MonoBehaviour
{
    public GameObject parent;
    public Camera c;

    private bool placing = false;
    private Vector3 point = new Vector3();

    void OnSelect()
    {
        placing = !placing;
    }


    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(c.transform.position, c.transform.forward, out hit, 30f))
        {
            if (placing)
            {
                parent.transform.position = point;
                parent.transform.rotation = Quaternion.EulerAngles(0, c.transform.rotation.y, 0);
            }
        }
    }
}
