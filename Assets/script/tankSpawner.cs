using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankSpawner : MonoBehaviour
{
    public TankView tankView;
    // Start is called before the first frame update
    void Start()
    {
        createTank();
    }

    private void Update()
    {
    }
    private void createTank() 
    {
        TankModel tankModel = new TankModel(30,20);

                 
        TankController tankController = new TankController(tankModel, tankView);

    }
}
