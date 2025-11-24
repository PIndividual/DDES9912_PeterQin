
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class Wonder_To_Target : MonoBehaviour
{

    public NavMeshAgent AI;
    public Transform nextCentrePoint; //创建新路径点基于的中心位置，可以是某个参照物或者是自身，后者将会起到大范围移动的效果
    public float nextRange; //创建新路径点距离自身当前位置的距离
    private Vector3 nextLocation;
    Animator Animate;
    public Transform finalLocation;
    //public float activateDistance;
    private bool stage2;
    public float flexDistance;//到达最终位置后开始鼓掌的距离
    public UnityEvent clap;

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
        //Debug.Log (stage2);
        if (stage2 == false)
        {

                if (AI.remainingDistance <= AI.stoppingDistance)
                {
                    
                    nextLocation = nextCentrePoint.position + Random.insideUnitSphere * nextRange;//https://docs.unity3d.com/6000.2/Documentation/ScriptReference/Random-insideUnitSphere.html
                
                    AI.SetDestination(nextLocation);


                    //Debug.DrawRay(newLocation, Vector3.up, Color.blue, 1.0f);
                }
        }
        else if (stage2 == true)
        {
            AI.destination = finalLocation.position;//可以尝试把这里改成整个结构并抬高stopping distance到一个大一点的数值，从而修复有时碰到的面向方向错误的问题
            
            float distanceToTarget = Vector3.Distance(transform.position, finalLocation.position);
            //Debug.Log (distanceToTarget);
            if (distanceToTarget< flexDistance)
            {
                AI.isStopped = true;
                Animate.SetBool("Clap", true);
                clap.Invoke();
            }
        }


    }

    public void NewTarget()
    {
        stage2 = true;   
    }
}
