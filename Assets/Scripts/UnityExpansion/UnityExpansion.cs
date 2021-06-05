using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public static class UnityExpansion
{
    // �{�^���R���|�[�l���g�̊g���@�\
    public static void SetListener(this Button.ButtonClickedEvent self, UnityAction call)
    {
        self.RemoveAllListeners();
        self.AddListener(call);
    }

}
