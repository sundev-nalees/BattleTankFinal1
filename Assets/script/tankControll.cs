using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class tankControll : MonoBehaviour
{
    public CharacterController controller;
    

    public float speed= 40f;
    public float turnSpeed=10f;
    public AudioSource MovementAudio;
    public AudioClip EngineIdle;
    public AudioClip EngineDriving;
    public float PitchRange = 0.2f;

    public Joystick joystick;

    private string MovemtAxisName;
    private string TurnAxisName;
    private Rigidbody rb;
    private float MovementInputValue;
    private float TurnInputValue;
    private float OrginalPitch;




    //public Joystick joystick;

    //loat horizontalMove = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        rb.isKinematic = false;
        MovementInputValue = 0f;
        TurnInputValue = 0f;
    }
    private void OnDisable()
    {
        rb.isKinematic = true;
    }
    private void Start()
    {
        OrginalPitch = MovementAudio.pitch;
    }
    // Update is called once per frame

    void Update()
    {
        //keyboard
        MovementInputValue = Input.GetAxis("Vertical");
        TurnInputValue = Input.GetAxis("Horizontal");
        //joystick
        MovementInputValue = joystick.Vertical;
        TurnInputValue = joystick.Horizontal;
        EngineAudio();
    }

    private void EngineAudio() 
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

    private void FixedUpdate()
    {
        Move();
        Turn();
    }
    private void Move()
    {
        Vector3 movement = transform.forward * MovementInputValue * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

    }
    private void Turn() 
    {
        float turn = TurnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
