
using UnityEngine;

public class TankModel
{
    private TankController tankController;
    public float speed = 7f;
    public float turnSpeed = 2f;
    public TankModel(float _speed,float _turnSpeed) 
    {
        speed = _speed;
        turnSpeed = _turnSpeed;
    }

    public void SetTankController(TankController _tankController) 
    {
        if (_tankController == null) 
        {
            Debug.Log("0");
        }
        tankController = _tankController;
    }
}
