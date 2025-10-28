
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Wonder_Around : MonoBehaviour
{

    public NavMeshAgent AI;
    public float range; //创建新路径点距离自身当前位置的距离
    public Transform centrePoint; //创建新路径点基于的中心位置，可以是某个参照物或者是自身，后者将会起到大范围移动的效果
    public Vector3 newLocation;

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
            newLocation = centrePoint.position + Random.insideUnitSphere * range;

            AI.SetDestination(newLocation);

          
           // Debug.DrawRay(newLocation, Vector3.up, Color.blue, 1.0f);
        }
    }
}
