using UnityEngine;
using TMPro; // Use TMPro instead of UnityEngine.UI

public class WandInteraction : MonoBehaviour
{
    // Drag your TextMeshProUGUI or TextMeshPro text object here in the Inspector
    public TextMeshPro uiText; 

    private string defaultText = "UI"; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Evidence"))
        {
            uiText.text = "Press Y to pick up evidence";
        }
        else if (other.CompareTag("Pickable"))
        {
            uiText.text = "Hold Trigger to drag object";
        }
    }

    void OnTriggerExit(Collider other)
    {
        uiText.text = defaultText;
    }
}