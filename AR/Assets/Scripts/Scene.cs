
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class Scene : MonoBehaviour
{

    public GameObject cursor;
    public GameObject Focused { get; private set; }
    public Scene Instance { get; private set; }


    private GestureRecognizer recognizer;
    private MeshRenderer Renderer;
    private readonly RaycastHit[] rayHit = new RaycastHit[5];
    

    void Awake()
    {
        Instance = this;
        recognizer = new GestureRecognizer();
        recognizer.Tapped += (args) =>
        {
            if (Focused != null)
            {
                Focused.SendMessageUpwards("OnSelect", SendMessageOptions.DontRequireReceiver);
            }
            

        };
        recognizer.StartCapturingGestures();
        Renderer = cursor.GetComponent<MeshRenderer>();
    }

    
    void Update()
    {
        GameObject oldFocused = Focused;

        if (Physics.RaycastNonAlloc(Camera.main.transform.position,Camera.main.transform.forward,rayHit,Mathf.Infinity,~0)>0)
        {
            Renderer.enabled = true;
            foreach ( RaycastHit hit in rayHit)
            {

                cursor.transform.position = hit.point;
                cursor.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                Focused = hit.collider.gameObject;
            }
        }

        else
        {
            Focused = null;
            Renderer.enabled = false;
        }
        if (Focused != oldFocused)
        {
            recognizer.CancelGestures();
            recognizer.StartCapturingGestures();
        }
    }
}
