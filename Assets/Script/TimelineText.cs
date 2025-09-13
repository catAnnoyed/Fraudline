using UnityEngine;
using TMPro;

public class TimelineText : MonoBehaviour
{
    public TextMeshPro textUI;

    public void SetText(string message)
    {
        if (textUI != null)
            textUI.text = message;
    }
}