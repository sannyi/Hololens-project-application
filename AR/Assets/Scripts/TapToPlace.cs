
using UnityEngine;

public class TapToPlace : MonoBehaviour
{
    public GameObject parent;

    private bool placing = false;
    private Vector3 point = new Vector3();

    void OnSelect()
    {
        placing=!placing;
    }
  


    

    
    void Update()
    {
        RaycastHit hit;
            if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit,30f))
            {
                if (placing)
                {
                    parent.transform.position = point;
                parent.transform.rotation = Quaternion.EulerAngles(0, Camera.main.transform.rotation.y, 0);
            }
        }
    }
}
