using UnityEngine;
using TMPro;    
using TiltFive;

public class radioUI : MonoBehaviour
{
    public TextMeshPro UIText;
    public GameObject phone;
    private int i = 0;
    private string[] dialog;

    void Start()
    {
        // Renderer planeRenderer = gameObject.GetComponent<Renderer>();
        // Vector3 planeSize = planeRenderer.bounds.size;
        // UIText.transform.localScale = new Vector3(planeSize.x, planeSize.z, 1f);
        // Vector3 UIPosition = UIText.transform.position;
        // Vector3 UIPosition = UIText.transform.position;
        // phonePosition.y += 3f;
        // transform.position = phonePosition;
        // phonePosition.y += 3f;
        // UIText.transform.position = phonePosition;


        dialog = new string[] {
            "Victim \nHello",
            "Police \nThis is the police station",
            "Victim \nDo you have any update my case of scammer?",
            "Victim \nI need it to claim the lost from bsn",
            "Police \nYes, good news we found three possible suspect",
            "Police \nHowever, we dont have any conclusive evidence except for thier IP address"
        };

        if (UIText != null)
        {
            UIText.text = dialog[i];
            Debug.Log("Set text to: " + dialog[i]);
        }
        else
        {
            Debug.LogError("UIText is not assigned in Inspector!");
        }
    }

    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space) || TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.A))
        {
            if (i < dialog.Length - 1)
            {
                i++;
                UIText.text = dialog[i];
                Debug.Log("Set text to: " + dialog[i]);
            }
            else
            {
                GlobalInventoryManagerScript.Instance.phase = 1;
            //     UIText.gameObject.SetActive(false);
            //     gameObject.SetActive(false);
            }
        }
    }
}
