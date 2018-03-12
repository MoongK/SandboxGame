using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

    public Texture2D crosshair;
    Rect rect;
	
	void Update () {
        rect = new Rect((Screen.width + crosshair.width * 0.02f) / 2f,
                        (Screen.height + crosshair.width * 0.02f) / 2f,
                        Screen.width * 0.02f, Screen.width * 0.02f);	
	}

    private void OnGUI()
    {
        GUI.DrawTexture(rect, crosshair);
    }
}
