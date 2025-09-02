using UnityEngine;

public class GlobalItemComplete : MonoBehaviour
{
    public GameObject alarm;
    public GameObject keys;
    public GameObject diary;
    public GameObject shoe;
    public GameObject whiteboard;
    public GameObject letter;
    public GameObject USB;
    public GameObject usd;
    public static bool allItemsCollected = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!alarm.activeSelf && !keys.activeSelf && !diary.activeSelf && !shoe.activeSelf && !whiteboard.activeSelf && !letter.activeSelf && !USB.activeSelf && !usd.activeSelf && safe_show_ui.opened)
        {
            allItemsCollected = true;
            Debug.Log("All items collected!");
            // You can add additional logic here, such as triggering an event or updating the game state
        }
    }
}
