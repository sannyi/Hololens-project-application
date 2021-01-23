using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject person;
    public float seconds;

    private Vector3 point = new Vector3(0,0,0);
    private RaycastHit[] rayHit = new RaycastHit[5];

    
    void OnSelect()
    {
        person.transform.position = Vector3.Lerp(person.transform.position, point, seconds * Time.deltaTime);
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Physics.RaycastNonAlloc(Camera.main.transform.position, Camera.main.transform.forward, rayHit, Mathf.Infinity, ~0) > 0)
        {
           
            foreach (RaycastHit hit in rayHit)
            {

                point.x = Mathf.Clamp(hit.point.x, -290f, 6970f);
                point.y = Mathf.Clamp(hit.point.y, -40f, 1860f);
                point.z = Mathf.Clamp(hit.point.z, -1700f, 140f);
            }
        }

    }
}
