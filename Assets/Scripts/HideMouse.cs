using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class HideMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
         // Vérifiez le système d'exploitation
        if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer)
        {
            // Si c'est un système d'exploitation Mac, ajustez la taille du curseur
            Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
            Cursor.visible = true; // Assurez-vous que le curseur est visible
            Cursor.SetCursor(Texture2D.whiteTexture, Vector2.zero, CursorMode.Auto);
        }
    }
}


