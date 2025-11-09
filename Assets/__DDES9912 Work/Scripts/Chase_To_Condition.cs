using UnityEngine;
using UnityEngine.AI;



[RequireComponent(typeof(NavMeshAgent))]
public class Chase_To_Condition : MonoBehaviour
{
    public NavMeshAgent AI;
    public Transform target;
    Animator Animate;//https://docs.unity3d.com/6000.2/Documentation/ScriptReference/Animator.SetFloat.html



    [Header("Chase and Escape settings")]
    public float activateDistance;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AI = GetComponent<NavMeshAgent>();
        Animate = gameObject.GetComponent<Animator>();
        Animate.SetFloat("ReachTarget", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget < activateDistance) {
            AI.destination = target.position;
        }
        
        if (distanceToTarget < 0.2) {
            Animate.SetFloat("ReachTarget", 1.0f);
        }
        Debug.Log(distanceToTarget);

    }
}
