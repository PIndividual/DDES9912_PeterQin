using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Chase_Around : MonoBehaviour
{
    public NavMeshAgent AI;
    public Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AI = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        AI.destination = target.position;

    }
}
