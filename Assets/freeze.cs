using UnityEngine;
using System.Collections;
using StarterAssets;

public class freeze : MonoBehaviour
{
    public static int visit = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (visit == 0)
        {
            StartCoroutine(pause());
        }
        
    }

    // Update is called once per frame
    IEnumerator pause()
    {
        GetComponent<ThirdPersonController>().enabled = false;
        yield return new WaitForSeconds(5f);
        GetComponent<ThirdPersonController>().enabled = true;
        visit = 1;
    }
}
