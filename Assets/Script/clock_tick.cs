using UnityEngine;
using TMPro;

public class CustomClockTMP : MonoBehaviour
{
    public AudioSource audioSource;
    public float timeScale = 60f;

    public int hours;
    public int minutes;
    public float seconds;
    public bool alarmtriggered = false;
    void Update()
    {
        // if (!alarmtriggered)
        // {
        //     seconds += Time.deltaTime * timeScale;

        //     if (seconds >= 60f)
        //     {
        //         seconds -= 60f;
        //         minutes++;
        //     }

        //     if (minutes >= 60)
        //     {
        //         minutes = 0;
        //         hours++;
        //     }

        //     if (hours >= 24)
        //     {
        //         hours = 0;
        //     }
        // }
        hours = GlobalInventoryManagerScript.Instance.hours;
        minutes = GlobalInventoryManagerScript.Instance.minutes;
        seconds = GlobalInventoryManagerScript.Instance.seconds;
        if (gameObject.GetComponent<TextMeshPro>() != null)
        {
            gameObject.GetComponent<TextMeshPro>().text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, (int)seconds);
        }
        if (gameObject.GetComponent<TextMeshPro>().text == "07:00:00" && !alarmtriggered && GlobalInventoryManagerScript.Instance.alarmtriggered)
        {
            audioSource.Play();
            alarmtriggered = true;
        }
    }
}
