using UnityEngine;
using TiltFive;
using UnityEngine.SceneManagement;
using TMPro;

public class script : MonoBehaviour
{
    public GameObject doorui;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorui = GameObject.Find("maindoorui");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is near the door");
            doorui.GetComponent<TextMeshPro>().text = "Press '1' to enter the jail cell";
            if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.One) || UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("police");
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorui.GetComponent<TextMeshPro>().text = "";
            Debug.Log("Player exited the door trigger area.");
        }
    }
}
