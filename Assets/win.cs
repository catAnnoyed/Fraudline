using UnityEditorInternal;
using UnityEngine;
using TMPro;
using System;

public class win : MonoBehaviour
{
    public TextMeshPro textUI;

    public void SetText(String message)
    {
        if (textUI != null)
            textUI.text = message;
    }
}
