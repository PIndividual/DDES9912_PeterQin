using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnBump : MonoBehaviour
{
    public UnityEvent onBump;

    private void OnCollisionEnter(Collision collision)
    {
        onBump.Invoke();
        Debug.Log("Bump detected and event invoked");
    }
}
