using UnityEngine;

public class followcam : MonoBehaviour
{
    [SerializeField]Transform thing;
    void Update()
    {
        transform.position = thing.position;
        //-10f, kinda move closer to player's side otherwise overlap
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }
}
