using System.Collections;
using UnityEngine;
using TMPro;
public class rating : MonoBehaviour
{
    public GameObject object1;
    public static int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DelayTimer());
    }

    IEnumerator DelayTimer()
    {
        yield return new WaitForSeconds(0.5f);
        object1 = cursorHighlight.platform1Obj;
        if (object1.name == "alarm")
        {
            score = 20;
        }
        else if (object1.name == "Keys")
        {
            score = 20;
        }
        else if (object1.name == "Shoe")
        {
            score = 20;
        }
        else if (object1.name == "Diario")
        {
            score = 60;
        }
        else if (object1.name == "whiteboard")
        {
            score = 60;
        }
        else if (object1.name == "USB")
        {
            score = 60;
        }
        else if (object1.name == "usd")
        {
            score = 100;
        }
        else if (object1.name == "Letter")
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
