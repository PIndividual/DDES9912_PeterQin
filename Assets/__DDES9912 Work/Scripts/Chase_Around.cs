using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Chase_Around : MonoBehaviour
{
    public NavMeshAgent AI;
    public Transform target;
    public float activateDistance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AI = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        //AI.destination = target.position;
        if (distanceToTarget < activateDistance)
        {

            AI.isStopped = false;
            AI.destination = target.position;
        }
        else
        {
            
            AI.isStopped = true;
           
        }

    }
}
