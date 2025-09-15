using UnityEngine;
using TMPro;
using TiltFive;
using UnityEngine.Playables;
using System.Globalization;
using UnityEditor.Callbacks;

public class radioUI : MonoBehaviour
{
    public TextMeshPro UIText;
    public GameObject phone;
    private int i = 0;
    private string[] dialog;
    public phoencutscene cutscene;
 

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
            "Victim \nGood Morning",
            "Police Officer \nThis is the police station",
            "Victim \nDo you have any update regarding the bank fraud case?",
            "Victim \nI need an official report to claim the lose from BSN",
            "Police Officer\nYes, we found three possible suspect",
            "Police Officer\nHowever, we do not have any conclusive evidence yet except for the scammer's hideout location",
            "Police Officer \nWe will be searching the hideout for clues and evidences"
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
        
        if ((UnityEngine.Input.GetKeyDown(KeyCode.Space) || TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.One)) && cutscene.num == 1)
        {
            if (i < dialog.Length - 1)
            {
                i++;
                UIText.text = dialog[i];
                Debug.Log("Set text to: " + dialog[i]);
            }
            else
            {
                cutscene.num = 2;
                cutscene.End();
                
                //     UIText.gameObject.SetActive(false);
                //     gameObject.SetActive(false);
            }
        }
    }


}
