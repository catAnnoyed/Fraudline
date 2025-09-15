using UnityEngine;
using TMPro;
using UnityEditor.Experimental.GraphView;

public class cutsceneUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject board;
    public TextMeshPro UIText;
    public GameObject radioUI;
    public GameObject door;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GlobalInventoryManagerScript.Instance.phase == 0 && radioUI.activeSelf)
        {
            UIText.text = "Press '1' to continue";
            transform.position = board.transform.position + new UnityEngine.Vector3(0, 2f, -1.5f);
        }
        else if (GlobalInventoryManagerScript.Instance.phase == 1 && !radioUI.activeSelf)
        {
            UIText.text = "Press '1' to continue";
            transform.position = board.transform.position + new UnityEngine.Vector3(0, 2.5f, -2f);
        }
        else if (GlobalInventoryManagerScript.Instance.phase == 2)
        {
            UIText.text = "Press '1' to vist scammer's hideout";
            transform.position = door.transform.position + new UnityEngine.Vector3(0, 2f, 0f);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            UIText.text = "";
        }
    }
    
}
