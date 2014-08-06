using System.Runtime.Serialization.Formatters;
using UnityEngine;
using System.Collections;

public class ExitApplication : MonoBehaviour
{
    public string nivo;


    void Start()
    {
      
    }

    // Update is called once per frame
	void Update () {

if (Input.GetKeyDown(KeyCode.Escape) == true)
{
Application.Quit();
}

if (Input.GetKeyDown(KeyCode.Return) == true)
{
    Application.LoadLevel(nivo);
 


}
	}
}
