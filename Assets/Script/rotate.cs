using UnityEngine;

public class rotate : MonoBehaviour
{
    public Transform headset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject glasses = GameObject.Find("Glasses 2");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(headset);
        transform.Rotate(0, 180, 0);
    }
}
