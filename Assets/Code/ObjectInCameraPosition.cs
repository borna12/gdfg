using System;
using UnityEngine;
using System.Collections;

public class ObjectInCameraPosition : MonoBehaviour
{
    //klasa se stavlja na kameru za svaki objekt (healthbar, tajmer i itd.)
    public GameObject objectTarget;
    //koriste se decimalne vrijednosti između 0 i 1 za x i y
    public Vector3 screenPosition = new Vector3(0, 0, 20);

    // Use this for initialization
    void Update()
    {

        if (objectTarget != null)
        {
            objectTarget.transform.position = Camera.main.ViewportToWorldPoint(screenPosition);
        }
    }


}
