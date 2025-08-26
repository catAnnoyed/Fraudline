using System;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class GlobalInventoryManagerScript : MonoBehaviour
{
    public static GlobalInventoryManagerScript Instance;
    public bool[] itemStatus;
    public int itemNum;
    public bool alarmtriggered = false;
    public int hours = 06;
    public int minutes = 50;
    public float seconds = 0f;
    public float timeScale = 60f;
    public string test = "Hey";
    public int phase;
    public Boolean[] opened;

    void Start()
    {
        itemStatus = new bool[itemNum];
        opened = new bool[itemNum];
        phase = 0;

        for (int i = 0; i < itemNum; i++)
        {
            itemStatus[i] = false;
        }

    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        //temp
        //  if (Input.GetKeyDown(KeyCode.S))
        // {
        //     addToInventory(0);
        // }

        // if (Input.GetKeyDown(KeyCode.R))
        // {
        //     addToInventory(1);
        // }

        if (!alarmtriggered)
        {
            Debug.Log("not yet triggered");
            if (hours < 7)
            {
                seconds += Time.deltaTime * timeScale;

                if (seconds >= 60f)
                {
                    seconds -= 60f;
                    minutes++;
                }

                if (minutes >= 60)
                {
                    minutes = 0;
                    hours++;
                }
            }
            else
            {
                alarmtriggered = true;
            }
        }
    }

    public void addToInventory(int index)
    {
        if (index >= 0 && index < itemNum)
        {
            itemStatus[index] = true;
            Debug.Log($"Item {index} added to inventory.");
        }
        else
        {
            Debug.LogWarning("Invalid item index.");
        }
    }

}