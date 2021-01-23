
using UnityEngine;

public class SetupCam : MonoBehaviour
{
    private new Camera camera;
#if UNITY_STANDALONE_WIN || UNITY_EDITOR
    //public float speedH =10;
   // public float speedV = 10;
   // private float pitch, yaw;
    //public GameObject[] caravanInterior = new GameObject[2];
  //  public GameObject furniture;
#endif
    private void Awake()
    {
         camera = this.GetComponent<Camera>();
        
    }

#if UNITY_STANDALONE_WIN || UNITY_EDITOR
   
    private void Update()
    {
       /* yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        if(Input.GetMouseButton(0) && GameObject.Find("Cursor").GetComponent<MeshRenderer>().enabled)
        {
            GetComponentInParent<Transform>().position = Vector3.Lerp(this.transform.position, new Vector3(GameObject.Find("Cursor").GetComponent<Transform>().position.x, this.transform.position.y,GameObject.Find("Cursor").GetComponent<Transform>().position.z),5*Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            foreach (GameObject g in caravanInterior)
            {
                g.active = !g.active;
            }
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            furniture.active = !furniture.active;
        }*/
        
    }
#endif
#if NETFX_CORE || UNITY_WSA || UNITY_WSA_10_0
    private void Start()

    {
        camera.clearFlags = CameraClearFlags.SolidColor;
        camera.backgroundColor = Color.black;
        camera.nearClipPlane=0.25f;
        camera.farClipPlane = 10000;
       
    }

#endif
}
