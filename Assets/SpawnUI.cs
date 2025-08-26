using System.Collections;
using UnityEngine;
using TMPro;

public class SpawnUI : MonoBehaviour
{
    public GameObject ui;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ui = GameObject.Find("CanvasUI");
        StartCoroutine(changetext());
    }
    IEnumerator changetext()
    {
        ui.GetComponent<TextMeshPro>().text = "Task: Find clues and evidence to catch the scammer";
        yield return new WaitForSeconds(5);
        ui.GetComponent<TextMeshPro>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
