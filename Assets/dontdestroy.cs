using UnityEngine;

public class dontdestroy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Awake()
    {
         DontDestroyOnLoad(gameObject);
    }
}
