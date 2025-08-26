using UnityEngine;
using TiltFive;
using UnityEngine.InputSystem.Interactions;
using JetBrains.Annotations;
using Unity.VisualScripting;

public class pickItem : MonoBehaviour
{
    public GameObject pickedItem;
    public AudioSource audiosource;
    public inventoryHouseIM inventorylist;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider obj)
    {
        if (obj.gameObject.CompareTag("pickable"))
        {
            pickedItem = obj.gameObject;
            if (TiltFive.Input.GetTrigger() > 0.5f || UnityEngine.Input.GetKeyDown(KeyCode.F))
            {
                pickedItem.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            }
        }

        if (obj.gameObject.CompareTag("evidence"))
        {
            pickedItem = obj.gameObject;

            if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.Y) ||UnityEngine.Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("F pressed");
                for (int i = 0; i < inventorylist.items.Length; i++)
                {
                    if (obj.gameObject.name == (inventorylist.items[i].name))
                    {
                        GlobalInventoryManagerScript.Instance.addToInventory(i);
                        audiosource.Play();
                    }
                }
            }
            
            

        }
    }
}
