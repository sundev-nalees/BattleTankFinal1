
using UnityEngine;

public class TankController
{

    private TankModel tankModel;

    private TankView tankView;

    private Rigidbody rb;

    public  TankController(TankModel _tankModel,TankView _tankView) 
    {
        tankModel = _tankModel;
        
        tankView = GameObject.Instantiate<TankView>(_tankView);
        rb =tankView.GetRigidbody();
        tankModel.SetTankController(this);
        tankView.SetTankController(this);
      
    }

    public void Move(float MovementInputValue,float speed)
    {
        Vector3 movement = tankView.transform.forward * MovementInputValue * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

    }
    public void Turn(float TurnInputValue,float turnSpeed)
    {
        float turn = TurnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
    public TankModel GetTankModel() 
    {
        return tankModel;
    }
    /*private void EngineAudio(float MovementInputValue,float TurnInputValue,)
    {
        if (Mathf.Abs(MovementInputValue) < 0.1f && Mathf.Abs(TurnInputValue) < 0.1f)
        {
            if (MovementAudio.clip == EngineDriving)
            {
                MovementAudio.clip = EngineIdle;
                MovementAudio.pitch = Random.Range(OrginalPitch - PitchRange, OrginalPitch + PitchRange);
                MovementAudio.Play();
            }
        }
        else
        {
            if (MovementAudio.clip == EngineIdle)
            {
                MovementAudio.clip = EngineDriving;
                MovementAudio.pitch = Random.Range(OrginalPitch - PitchRange, OrginalPitch + PitchRange);
                MovementAudio.Play();
            }
        }
    }
    */
}
