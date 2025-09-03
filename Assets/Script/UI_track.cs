using UnityEngine;

public class UI_track : MonoBehaviour
{
    public GameObject gameboard;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameboard = GameObject.Find("Tilt Five Game Board");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = gameboard.transform.position + new Vector3(0, 9.75f, 0);
    }
}
