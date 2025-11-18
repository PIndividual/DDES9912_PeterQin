
using UnityEngine;
using UnityEngine.AI;
//using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class Wonder_To_Target : MonoBehaviour
{

    public NavMeshAgent AI;
    public Transform nextCentrePoint; //创建新路径点基于的中心位置，可以是某个参照物或者是自身，后者将会起到大范围移动的效果
    public float nextRange; //创建新路径点距离自身当前位置的距离
    private Vector3 nextLocation;
    Animator Animate;
    public Transform finalLocation;
    public float activateDistance;
    private bool stage2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AI = GetComponent<NavMeshAgent>();
        Animate = gameObject.GetComponent<Animator>();
        Animate.SetBool("Clap", false);
        stage2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log (stage2);
        if (stage2 == false)
        {
            //AI.destination = finalLocation.position;
            if (AI.remainingDistance <= AI.stoppingDistance)
            {
                // 1. 直接在中心点周围的球体内生成一个随机点
                nextLocation = nextCentrePoint.position + Random.insideUnitSphere * nextRange;//https://docs.unity3d.com/6000.2/Documentation/ScriptReference/Random-insideUnitSphere.html

                AI.SetDestination(nextLocation);


                //Debug.DrawRay(newLocation, Vector3.up, Color.blue, 1.0f);
            }
        }
        else if (stage2 == true)
        {
            AI.destination = finalLocation.position;
            if (AI.remainingDistance <= AI.stoppingDistance)
            {
                AI.isStopped = true;
                Animate.SetBool("Clap", true);
            }
        }


    }

    public void NewTarget()
    {
        stage2 = true;   
    }
}
