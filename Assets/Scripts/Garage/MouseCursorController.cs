using UnityEngine;

public class MouseCursorController : MonoBehaviour
{
    private bool cursorVisible = false;

    private void Start()
    {
        HideCursor();
    }

    public void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cursorVisible = true;
    }

    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cursorVisible = false;
    }

    public void ToggleCursorVisibility()
    {
        if (cursorVisible)
            HideCursor();
        else
            ShowCursor();
    }
}
