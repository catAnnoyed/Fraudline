using UnityEngine;
using TMPro;
public class inventoryHouseIM : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject[] items;
    public GameObject ui;
    void Start()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if ((items[i] != null) && GlobalInventoryManagerScript.Instance.itemStatus[i] && items[i].activeSelf)
            {
                items[i].SetActive(false);
                ui.GetComponent<TextMeshPro>().text = "";
                Debug.Log($"Item {i} activated.");
            }
        }

        Debug.Log(GlobalInventoryManagerScript.Instance.test);

    }
}
