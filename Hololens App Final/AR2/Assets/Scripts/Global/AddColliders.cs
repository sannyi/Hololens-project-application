using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddColliders : MonoBehaviour
{
    // Start is called before the first frame update
    public Material mat;

    void Start()
    {
        foreach(Transform child in this.transform)
        {
            child.gameObject.GetComponent<MeshRenderer>().material = mat;
            child.gameObject.AddComponent<MeshCollider>();
        }
    }

    // Update is called once per frame
  
}
