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
            case 1:
                return KeyCode.Space;
            default:
                return KeyCode.None;
        }
    }


}
