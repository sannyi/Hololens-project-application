
using UnityEngine;
using System.Collections.Generic;


public class Furniture : MonoBehaviour
{
    public void Toggle()
    {
        List<GameObject> g = new List<GameObject>();
        switch(this.name)
        {
            case "FurnitureButton":
                g.Add(GameObject.Find("Furniture"));

                break;
            case "InstallationsButton":
                g.Add(GameObject.Find("instalacije_prikljucki"));
                g.Add(GameObject.Find("instalacije_ogrodje"));
                break;
            default: throw new System.Exception();
        }
        foreach(GameObject ga in g)
        {
            ga.active = !ga.active;
        }
        g.Clear();
    }
}
