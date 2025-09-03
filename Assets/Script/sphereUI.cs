using UnityEngine;
using TMPro;

public class sphereUI : MonoBehaviour
{
    public GameObject ui;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ui = GameObject.Find("CanvasUI");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("pickable"))
        {
            ui.GetComponent<TextMeshPro>().text = "Hold down trigger to pick object";
        }
        else if (other.gameObject.CompareTag("evidence"))
        {
            ui.GetComponent<TextMeshPro>().text = "press Y to pick up evidence";
        }
    }
}