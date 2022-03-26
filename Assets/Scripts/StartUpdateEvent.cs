using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartUpdateEvent : MonoBehaviour
{
    public UnityEvent OnStart;
    public UnityEvent OnUpdate;


    void Start()
    {
        OnStart?.Invoke();
    }

    
    void Update()
    {
        OnUpdate?.Invoke();
    }
}
