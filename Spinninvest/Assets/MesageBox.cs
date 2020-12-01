using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesageBox : MonoBehaviour
{
    public Texture BoxTexture;      // Drag a Texture onto this item in the Inspector

    GUIContent content;

    void Start()
    {
        content = new GUIContent("This is a box", BoxTexture, "This is a tooltip");
    }

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), content);
    }
}
