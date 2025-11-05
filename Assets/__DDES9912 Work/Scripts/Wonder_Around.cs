
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Wonder_Around : MonoBehaviour
{

    public NavMeshAgent AI;
    public Transform nextCentrePoint; //创建新路径点基于的中心位置，可以是某个参照物或者是自身，后者将会起到大范围移动的效果
    public float nextRange; //创建新路径点距离自身当前位置的距离
    private Vector3 nextLocation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AI = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AI.remainingDistance <= AI.stoppingDistance)
        {
            // 1. 直接在中心点周围的球体内生成一个随机点
            nextLocation = nextCentrePoint.position + Random.insideUnitSphere * nextRange;//https://docs.unity3d.com/6000.2/Documentation/ScriptReference/Random-insideUnitSphere.html

            AI.SetDestination(nextLocation);

          
           //Debug.DrawRay(newLocation, Vector3.up, Color.blue, 1.0f);
        }
    }
}
