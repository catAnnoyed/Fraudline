using UnityEngine;
using TiltFive;
using UnityEngine.InputSystem.Interactions;
using JetBrains.Annotations;
using Unity.VisualScripting;

public class RaycastpickItem : MonoBehaviour
{
    public GameObject pickedItem;
    public AudioSource audiosource;
    public inventoryHouseIM inventorylist;

    // Maximum ray distance
    public float rayDistance = 5f;

    void Update()
    {
        // Create a ray starting from this object's position going forward
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Draw the ray in the Scene view (red line for debugging)
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            GameObject target = hit.collider.gameObject;

            // If the ray hits a pickable item
            if (pickedItem == null)
            {

                if (target.CompareTag("pickable"))
                {
                    if (TiltFive.Input.GetTrigger() > 0.5f || UnityEngine.Input.GetKeyDown(KeyCode.F))
                    {

                        // Parent the object to the wand
                        pickedItem = target;
                        pickedItem.transform.SetParent(transform);
                        pickedItem.transform.localPosition = Vector3.forward * rayDistance;
                        pickedItem.GetComponent<Rigidbody>().isKinematic = true;
                    }
                }
            }

            // If holding something, check for release
            if (pickedItem != null && pickedItem.CompareTag("pickable"))
            {
                if (TiltFive.Input.GetTrigger() <= 0.5f && !UnityEngine.Input.GetKey(KeyCode.F))
                {
                    // Un-parent the object when released
                pickedItem.GetComponent<Rigidbody>().isKinematic = false;
                    pickedItem.transform.SetParent(null);
                    pickedItem = null;
                }
            }

            // If the ray hits evidence
            if (target.CompareTag("evidence"))
            {

                if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.Y) || UnityEngine.Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("F pressed on evidence");

                    for (int i = 0; i < inventorylist.items.Length; i++)
                    {
                        if (target.name == inventorylist.items[i].name)
                        {
                            GlobalInventoryManagerScript.Instance.addToInventory(i);
                            audiosource.Play();
                        }
                    }
                }
            }
        }
    }
}
