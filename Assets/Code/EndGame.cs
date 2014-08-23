using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour
{
     void OnMouseDown()
{

    if (Input.GetMouseButtonDown(0))
        Application.Quit();

}
}
