using UnityEngine;

public class platform3script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       foreach (Transform child in transform)
       {
         if (child.gameObject.name == global.eviarray[2])
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
