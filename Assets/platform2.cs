using UnityEngine;

public class platform2script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       foreach (Transform child in transform)
       {
         if (child.gameObject.name == global.eviarray[1])
         {
                child.gameObject.SetActive(true);
         } 
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
