using System.Collections;
using UnityEngine;
using TMPro;
public class rating2 : MonoBehaviour
{
    public GameObject Objects;
    public static int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DelayTimer());
    }

    IEnumerator DelayTimer()
    {
        yield return new WaitForSeconds(0.5f);
        Objects = cursorHighlight.platform2Obj;
        if (Objects.name == "alarm")
        {
            score = 20;
        }
        else if (Objects.name == "Keys")
        {
            score = 20;
        }
        else if (Objects.name == "Shoe")
        {
            score = 20;
        }
        else if (Objects.name == "Diario")
        {
            score = 60;
        }
        else if (Objects.name == "whiteboard")
        {
            score = 60;
        }
        else if (Objects.name == "USB")
        {
            score = 60;
        }
        else if (Objects.name == "usd")
        {
            score = 100;
        }
        else if (Objects.name == "Letter")
        {
            score = 60;
        }
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMeshPro>().text = score.ToString() + "%";
        if (score <= 50)
        {
            gameObject.GetComponent<TextMeshPro>().color = Color.red;
        }
        else if (score > 50 && score <= 80)
        {
            gameObject.GetComponent<TextMeshPro>().color = Color.yellow;
        }
        else if (score >= 80)
        {
            gameObject.GetComponent<TextMeshPro>().color = Color.green;
        }
    }
}
