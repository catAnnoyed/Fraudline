using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ItemDescription : MonoBehaviour
{
    public GameObject description;
    public GameObject alarm;
    public GameObject keys;
    public GameObject diary;
    public GameObject shoe;
    public GameObject whiteboard;
    public GameObject letter;
    public GameObject USB;
    public GameObject usd;
    public float yoffset = 1.5f; // Offset to position the description above the item
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider other)
    {
        description.transform.position = other.transform.position + new Vector3(0, 0 + yoffset, 0);
        if (other.gameObject == alarm)
        {
            description.GetComponent<TextMeshPro>().text = "Wake Up Alarm";
        }
        else if (other.gameObject == keys)
        {
            description.GetComponent<TextMeshPro>().text = "Secret Room Keys";
        }
        else if (other.gameObject == diary)
        {
            description.GetComponent<TextMeshPro>().text = "James's Diary";
        }
        else if (other.gameObject == shoe)
        {
            description.GetComponent<TextMeshPro>().text = "Small Shoe";
        }
        else if (other.gameObject == whiteboard)
        {
            description.GetComponent<TextMeshPro>().text = "Scammer's Whiteboard";
        }
        else if (other.gameObject == letter)
        {
            description.GetComponent<TextMeshPro>().text = "Suspicious Letter";
        }
        else if (other.gameObject == USB)
        {
            description.GetComponent<TextMeshPro>().text = "Malware USB";
        }
        else if (other.gameObject == usd)
        {
            description.GetComponent<TextMeshPro>().text = "Counterfeit USD";
        }
    }
    void OnTriggerExit(Collider other)
    {
        description.GetComponent<TextMeshPro>().text = "";
    }
}
