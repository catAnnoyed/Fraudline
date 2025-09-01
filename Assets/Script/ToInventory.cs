using UnityEngine;
using UnityEngine.SceneManagement;
using TiltFive;


public class toInventory : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalInventoryManagerScript.Instance.phase == 2)
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.I) || TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.X))
            {
                SceneManager.LoadScene("inventory");
            }
        }
    }
}
