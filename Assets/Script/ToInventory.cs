using UnityEngine;
using UnityEngine.SceneManagement;
using TiltFive;


public class toInventory : MonoBehaviour
{
    public static string currentscene;
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
                if ((SceneManager.GetActiveScene().name != "inventory") && SceneManager.GetActiveScene().name != "Evidence scene" && SceneManager.GetActiveScene().name != "EviStrengthen")
                {
                    currentscene = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene("inventory");
                }
            }
        }
    }
}
