using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainThreadDispatcher : MonoBehaviour
{
    public bool SingleItemMode = false;

    private static MainThreadDispatcher _instance;

    public static MainThreadDispatcher Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            _instance.SingleItemMode = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (MainThreadDispatcher.Instance.SingleItemMode)
        {
            TaskManager.Instance.InvokeOne();
        }
        else
        {
            TaskManager.Instance.InvokeAll();
        }
    }
}
