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
        transform.Rotate(xspeed * Time.deltaTime, yspeed * Time.deltaTime, zspeed*Time.deltaTime);//Time.deltaTime的含义是每秒的时间，deltaTime代表每两帧之间的时间差，帧率越高数字越低，帧率越低数字越高，因此补全了不同系统之间帧率不同所带来的数字差
    }
}
