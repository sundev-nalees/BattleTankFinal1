using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView: MonoBehaviour
{
    private TankController tankController;
    private TankController x;

    public Rigidbody rb;
    private float speed;
    private float turnSpeed;
    //public Joystick joystick;

    private float MovementInputValue;
    private float TurnInputValue;
    // Start is called before the first frame update
    private void Start()
    {
        GameObject camera = GameObject.Find("Camera");
        camera.transform.SetParent(transform);
        camera.transform.position = new Vector3(0f, 3f, -4f);
    }
    // Update is called once per frame
    void Update()
    {
        Movement();

        if (MovementInputValue != 0)
        {
            if (tankController == null)
                Debug.Log("4");
            tankController.Move(MovementInputValue, tankController.GetTankModel().speed);
        }
        if (TurnInputValue != 0)
        {
            tankController.Turn(TurnInputValue, tankController.GetTankModel().turnSpeed);
        }
    }
    private void FixedUpdate()
    {
        
    }
    public Rigidbody GetRigidbody()
    {
        return GetComponent<Rigidbody>(); ;
    }
    private void Movement() 
    {
        if (tankController == null)
            Debug.Log("3");
        // Debug.Log(joystick);
        // MovementInputValue = joystick.Vertical;
        //TurnInputValue = joystick.Horizontal;
        MovementInputValue =  Input.GetAxis("Vertical");
        TurnInputValue =  Input.GetAxis("Horizontal");
    }
    public void SetTankController(TankController _tankController)
    {
    
        if (_tankController == null)
            Debug.Log("1");
        tankController = _tankController;
        //tankController.Move(10, tankController.GetTankModel().speed);
    }

    
}
