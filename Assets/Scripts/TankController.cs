using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    private TankModel tankModel;
    private TankView tankView;
    private Rigidbody rb;
    public TankController(TankModel _tankModel,TankView _tankView)
    {
        tankModel = _tankModel;
        tankView = GameObject.Instantiate<TankView>(_tankView);
        rb = tankView.GetRigidbody();
        tankModel.SetTankController(this);
        tankView.SetTankController(this);

        tankView.ChangeColor(tankModel.color);



    }
    public void Move(float movement, float movementSpeed)
    {
        rb.velocity=tankView.transform.forward * movement * movementSpeed;
    }

    public void Rotate(float roatate,float rotateSpeed)
    {
        Vector3 vector = new Vector3(0f, roatate * rotateSpeed, 0f);
        Quaternion deltaRoatation = Quaternion.Euler(vector * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRoatation);
    }

    public TankModel GetTankModel()
    {
        return tankModel;
    }
}
