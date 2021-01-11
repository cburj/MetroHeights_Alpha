using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Texture2D crosshair;

    /* Script: https://wintermutedigital.com/post/2020-01-29-the-ultimate-guide-to-custom-cursors-in-unity/ */
    void Start()
    {
        /* Used to place the cursor point at teh center of the cursor image rather than the top left corner*/
        Cursor.visible = true;
        Vector2 cursorOffset = new Vector2(crosshair.width / 2, crosshair.height / 2);
        Cursor.SetCursor(crosshair, cursorOffset, CursorMode.Auto);
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        /* Make sure the cursor is always visible */
        Cursor.visible = true;
    }
}
