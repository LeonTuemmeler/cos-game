using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AssistMode
{
    private static bool assistMode = false;

    public static void ToggleAssistMode(bool b)
    {
        assistMode = b;
    }
    
    public static void ToggleAssistMode()
    {
        assistMode = !assistMode;
    }
    
    public static bool GetAssistMode()
    {
        return assistMode;
    }
}
