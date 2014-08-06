using System;
using UnityEngine;
using System.Collections;

public class HeltbarPosition : MonoBehaviour
{
    public GameObject objectTarget;
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
