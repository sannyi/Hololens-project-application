
using UnityEngine;
using System.Collections;
#if NETFX_CORE || UNITY_WSA || UNITY_WSA_10_0
using UnityEngine.XR.WSA.Input;
#endif

public class Scene : MonoBehaviour
{
    
    public GameObject cursor;
    public GameObject[] interactables = new GameObject[2];
    private MeshRenderer Renderer;
    public Scene Instance { get; private set; }
    public Camera cam;
    private void Awake()
    {

        Renderer = cursor.GetComponent<MeshRenderer>();
        Instance = this;
    }

#if NETFX_CORE || UNITY_WSA || UNITY_WSA_10_0

    public GameObject Focused { get; private set; }
    private GestureRecognizer recognizer;
    void Start()
    {
       
        recognizer = new GestureRecognizer();
        recognizer.Tapped += (args) =>
        {
            if (Focused != null)
            {
                Focused.SendMessageUpwards("OnSelect", SendMessageOptions.DontRequireReceiver);
            }
            

        };
        recognizer.StartCapturingGestures();
        foreach (GameObject g in interactables)
            g.SetActive(true);

    Destroy(GameObject.Find("FurnitureButton"));
    Destroy( GameObject.Find("FurnitureButton"));
    }
 
    private void OnApplicationQuit()
    {
        recognizer.StopCapturingGestures();
        recognizer.Tapped -= (args) =>
        {
            if (Focused != null)
            {
                Focused.SendMessageUpwards("OnSelect", SendMessageOptions.DontRequireReceiver);
            }
        };
    }
#endif

    void Update()
    {
        #if NETFX_CORE || UNITY_WSA || UNITY_WSA_10_0
            GameObject oldFocused = Focused;
        #endif
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position,cam.transform.forward,out hit))
        {
            Renderer.enabled = true;
            
                cursor.transform.position = hit.point;
                cursor.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                #if NETFX_CORE || UNITY_WSA || UNITY_WSA_10_0
                    Focused = hit.collider.gameObject;
                #endif
            }
        

        else
        {
            #if NETFX_CORE || UNITY_WSA || UNITY_WSA_10_0
                Focused = null;
            #endif
            Renderer.enabled = false;
        }
            #if NETFX_CORE || UNITY_WSA || UNITY_WSA_10_0
                if (Focused != oldFocused)
                    {
                        recognizer.CancelGestures();
                        recognizer.StartCapturingGestures();
                    }
            #endif
    }
  
}
