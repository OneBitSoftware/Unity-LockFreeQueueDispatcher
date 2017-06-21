using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager
{
    public CircularQueue<Action> Queue;

    private static TaskManager _instance;

    public static TaskManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new TaskManager(); // Instantiate singleton on first use.
                _instance.Queue = new CircularQueue<Action>(1024000);
            }

            return _instance;
        }
    }

    public void Enqueue(Action function)
    {
        if (function == null) return;

        Queue.Enqueue(function);
    }

    public void InvokeOne()
    {
        Action dueAction;
        Queue.TryDequeue(out dueAction);
        if (dueAction != null) dueAction();
    }

    public void InvokeAll()
    {
        for (int i = 0; i < Queue.Count; i++)
        {
            InvokeOne();
        }
    }
}
