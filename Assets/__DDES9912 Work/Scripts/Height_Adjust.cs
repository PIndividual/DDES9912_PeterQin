using UnityEngine;

public class Height_Adjust : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float heightOffset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,heightOffset * Time.deltaTime);
    }
}
