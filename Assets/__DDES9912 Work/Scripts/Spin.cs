using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float yspeed;
    public float xspeed;
    public float zspeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xspeed * Time.deltaTime, yspeed * Time.deltaTime, zspeed*Time.deltaTime);//Time.deltaTime�ĺ�����ÿ���ʱ�䣬deltaTime����ÿ��֮֡���ʱ��֡��Խ������Խ�ͣ�֡��Խ������Խ�ߣ���˲�ȫ�˲�ͬϵͳ֮��֡�ʲ�ͬ�����������ֲ�
    }
}
