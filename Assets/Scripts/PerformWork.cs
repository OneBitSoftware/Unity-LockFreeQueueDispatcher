using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PerformWork : MonoBehaviour {

    public Text TextFieldToUpdate;

    public void DoSingleWorkItem_Click()
    {
        TaskManager.Instance.Enqueue(() => LongOperation("1"));
    }

    public void DoMultipleWorkItems_Click()
    {
        TaskManager.Instance.Enqueue(() => LongOperation("1"));
        TaskManager.Instance.Enqueue(() => LongOperation("2"));
        TaskManager.Instance.Enqueue(() => LongOperation("3"));
        TaskManager.Instance.Enqueue(() => LongOperation("4"));
        TaskManager.Instance.Enqueue(() => LongOperation("5"));
        TaskManager.Instance.Enqueue(() => LongOperation("6"));
    }

    private void LongOperation(string taskNumber)
    {
        System.Threading.Thread.Sleep(3000);
        TextFieldToUpdate.text = "Task " + taskNumber + " Slept for 3000ms " + DateTime.Now.ToString();
    }

    public void Perform1000Tasks()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        for (int i = 0; i < 1000000; i++)
        {
            TaskManager.Instance.Enqueue(() => {
                if (TextFieldToUpdate != null)
                    TextFieldToUpdate.text = i.ToString() + " item " + sw.ElapsedMilliseconds.ToString();
            });
        }

        sw.Stop();
    }
}
