using UnityEngine;
using UnityEngine.SceneManagement;

public class toHouse : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("house");
        }
    }

    
}
