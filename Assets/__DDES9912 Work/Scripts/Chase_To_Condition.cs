using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;



[RequireComponent(typeof(NavMeshAgent))]
public class Chase_To_Condition : MonoBehaviour
{
    public NavMeshAgent AI;
    public Transform target1;
    //public Transform target2;
    Animator Animate;//https://docs.unity3d.com/6000.2/Documentation/ScriptReference/Animator.SetFloat.html
    public UnityEvent actionOnTarget;
    public bool missionComplete;
    //Ported from Wonder_Around
    public Transform nextCentrePoint; //创建新路径点基于的中心位置，可以是某个参照物或者是自身，后者将会起到大范围移动的效果
    public float nextRange; //创建新路径点距离自身当前位置的距离
    private Vector3 nextLocation;



    [Header("Chase and Escape settings")]
    public float activateDistance;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AI = GetComponent<NavMeshAgent>();
        Animate = gameObject.GetComponent<Animator>();
        Animate.SetFloat("ReachTarget", 0);
        Animate.SetBool("missionComplete", false);
        missionComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        float distanceToTarget = Vector3.Distance(transform.position, target1.position);

        if (distanceToTarget < activateDistance) {
            AI.destination = target1.position;
        }
        
        if (distanceToTarget < 0.2 && 0<distanceToTarget) {
            Animate.SetFloat("ReachTarget", 1.0f);
            actionOnTarget.Invoke();
            Animate.SetBool("missionComplete", true);
            missionComplete = true;
        }

        if (missionComplete == true) {
            nextLocation = nextCentrePoint.position + Random.insideUnitSphere * nextRange;//https://docs.unity3d.com/6000.2/Documentation/ScriptReference/Random-insideUnitSphere.html
            activateDistance = 0;
            AI.SetDestination(nextLocation);
        }
        //Debug.Log(distanceToTarget);

    }
}
