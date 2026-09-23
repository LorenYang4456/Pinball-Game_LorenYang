using UnityEngine;

public class followcam : MonoBehaviour
{
    [SerializeField]Transform thing;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = thing.position;
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }
}
