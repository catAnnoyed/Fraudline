using UnityEngine;

public class offsetGlasses : MonoBehaviour
{
    public Transform meshChild;  // assign the child that holds the MeshRenderer

    void Start()
    {
        if (meshChild != null)
        {
            meshChild.localRotation = Quaternion.Euler(0,90,0);
        }
    }
}
