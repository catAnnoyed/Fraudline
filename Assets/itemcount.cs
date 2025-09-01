using UnityEngine;
using TMPro;

public class itemcount : MonoBehaviour
{
    public GameObject alarm;
    public GameObject keys;
    public GameObject diary;
    public GameObject shoe;
    public GameObject whiteboard;
    public GameObject letter;
    public GameObject USB;
    public GameObject usd;

    public int counter;

    // flags so each item is only counted once
    private bool alarmCounted = false;
    private bool keysCounted = false;
    private bool diaryCounted = false;
    private bool shoeCounted = false;
    private bool whiteboardCounted = false;
    private bool letterCounted = false;
    private bool USBCounted = false;
    private bool usdCounted = false;

    void Start()
    {
        counter = 0;
    }

    void Update()
    {
        GetComponent<TextMeshPro>().text = counter.ToString();

        if (alarm.activeSelf && !alarmCounted)
        {
            counter++;
            alarmCounted = true;
        }

        if (keys.activeSelf && !keysCounted)
        {
            counter++;
            keysCounted = true;
        }

        if (diary.activeSelf && !diaryCounted)
        {
            counter++;
            diaryCounted = true;
        }

        if (shoe.activeSelf && !shoeCounted)
        {
            counter++;
            shoeCounted = true;
        }

        if (whiteboard.activeSelf && !whiteboardCounted)
        {
            counter++;
            whiteboardCounted = true;
        }

        if (letter.activeSelf && !letterCounted)
        {
            counter++;
            letterCounted = true;
        }

        if (USB.activeSelf && !USBCounted)
        {
            counter++;
            USBCounted = true;
        }

        if (usd.activeSelf && !usdCounted)
        {
            counter++;
            usdCounted = true;
        }
    }
}
