using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle3 : MonoBehaviour
{
    public GameObject [] objects;
    void OnSelect()
    {
        foreach(GameObject g in objects)
        {
            g.active = !g.active;
        }
    }
}
