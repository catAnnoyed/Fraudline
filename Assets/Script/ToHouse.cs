using UnityEngine;
using UnityEngine.SceneManagement;

public class toHouse : MonoBehaviour
{
    public GameObject magnifyingglass;
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)||TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.B))
        {
            SceneManager.LoadScene("house");
        }
    }

    
}
