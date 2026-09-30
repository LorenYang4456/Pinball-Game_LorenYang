using UnityEngine;
using UnityEngine.InputSystem;

public class BallScript : MonoBehaviour
{
    Rigidbody2D myBody;
    InputAction jump;

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        jump = InputSystem.actions.FindAction("Jump");
        //myBody.AddForceY(500f);
        //myBody.AddForce(new Vector2(200f, 500f));
    }
    
    void Update()
    {
        if (jump.IsPressed())
        {

            myBody.AddForceY(500f);

        }
    }
}
