using UnityEngine;
using TMPro;

public class textappeardoor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<TextMeshPro>().text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&&GetComponent<TextMeshPro>().text == "")
        {
            GetComponent<TextMeshPro>().text = "Press A to open/close the door";
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<TextMeshPro>().text = "";
        }
    }
}
