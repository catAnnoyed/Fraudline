using UnityEngine;
using TMPro; // Use TMPro instead of UnityEngine.UI

public class Wand : MonoBehaviour
{
    // Drag your TextMeshProUGUI or TextMeshPro text object here in the Inspector
    public TextMeshPro uiText; 

    private string defaultText = "UI"; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pickable"))
        {
            uiText.text = "Hold Trigger to drag object";
        }
        else if (other.CompareTag("evidence"))
        {
            uiText.text = "Press Y to pick up evidence";
        }
    }

    void OnTriggerExit(Collider other)
    {
        uiText.text = defaultText;
    }
}