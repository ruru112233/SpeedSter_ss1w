using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameUtil
{
    public static KeyCode GetKeyCodeByLineNum(int lineNum)
    {
        switch (lineNum)
        {
            case 0:
                return KeyCode.DownArrow;
            case 1:
                return KeyCode.UpArrow;
            default:
                return KeyCode.None;
        }
    }

}
