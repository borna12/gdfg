using UnityEngine;
using System.Collections;

public class CustomCursor2 : MonoBehaviour {

    private int cursorWidth = 32;
    private int cursorHeight = 32;
    public Texture2D cursorImage;
    // Use this for initialization
    void Start()
    {
        Screen.showCursor = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnGUI()
    {
        if (Time.timeScale == 0)
        {
            GUI.depth = 0;
            GUI.DrawTexture(
                new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, cursorWidth, cursorHeight),
                cursorImage);

        }
        else 
        return;

    }
}
