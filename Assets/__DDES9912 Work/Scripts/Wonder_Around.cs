
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Wonder_Around : MonoBehaviour
{

    public NavMeshAgent AI;
    public float range; //������·�����������ǰλ�õľ���
    public Transform centrePoint; //������·������ڵ�����λ�ã�������ĳ��������������������߽����𵽴�Χ�ƶ���Ч��
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
            // 1. ֱ�������ĵ���Χ������������һ�������
            newLocation = centrePoint.position + Random.insideUnitSphere * range;

            AI.SetDestination(newLocation);

          
           // Debug.DrawRay(newLocation, Vector3.up, Color.blue, 1.0f);
        }
    }
}
