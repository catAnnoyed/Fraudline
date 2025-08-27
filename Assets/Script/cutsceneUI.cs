using UnityEngine;
using TMPro;

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

        if (GlobalInventoryManagerScript.Instance.phase == 0)
        {
            UIText.text = "Press A to continue";
            transform.position = board.transform.position + new UnityEngine.Vector3(0, 2f, -1.5f);
        }

        if (GlobalInventoryManagerScript.Instance.phase == 1 && !radioUI.activeSelf)
        {
            UIText.text = "Press A to continue";
            transform.position = board.transform.position + new UnityEngine.Vector3(0, 2.5f, -2f);
        }

        if (GlobalInventoryManagerScript.Instance.phase == 2)
        {
            UIText.text = "Press A to vist scammer's house";
            transform.position = door.transform.position + new UnityEngine.Vector3(0, 2.5f, 0f);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
    
}
