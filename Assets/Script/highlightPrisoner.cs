using UnityEngine;

public class highlightPrisoner : MonoBehaviour
{
    public GameObject[] prisoners;
    private Renderer[] renderers;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void highlight(int i)
    {
        renderers = prisoners[i].GetComponentsInChildren<Renderer>();
        for (int j = 0; j < renderers.Length; j++)
        {
            Material mat = renderers[j].material;
            mat.EnableKeyword("_EMISSION");
            mat.SetColor("_EmissionColor", Color.white * 0.055f);
        }

    }

    public void dontHighlight()
    {
        for (int j = 0; j < 3; j++)
        {
            renderers = prisoners[j].GetComponentsInChildren<Renderer>();
            for (int k = 0; k < renderers.Length; k++)
            {
                Material mat = renderers[k].material;
                mat.DisableKeyword("_EMISSION");
            }
        }
    }
}
