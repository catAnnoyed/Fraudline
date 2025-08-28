using UnityEngine;
using System.Collections;
using StarterAssets;

public class freeze : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(pause());
    }

    // Update is called once per frame
    IEnumerator pause()
    {
        GetComponent<ThirdPersonController>().enabled = false;
        yield return new WaitForSeconds(5f);
        GetComponent<ThirdPersonController>().enabled = true;
    }
}
