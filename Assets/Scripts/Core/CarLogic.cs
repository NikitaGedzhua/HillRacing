using System;
using UnityEngine;

public class CarLogic : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;
    [Space]
    [SerializeField] private Rigidbody2D carRigidBody;
    [SerializeField] private Rigidbody2D backTire;
    [SerializeField] private Rigidbody2D frontTire;
       
    private bool _alive = true;
    private bool _isGasPressed;
    private bool _isBrakePressed;
    
    private void OnEnable()
    {
        this.Subscribe(eEventType.GroundTouched, (o) => OnPlayerDead());
    }

    private void OnDisable()
    {
        this.Unsubscribe(eEventType.GroundTouched, (o) => OnPlayerDead());
    }

    private void OnPlayerDead()
    {
        _alive = false;
    }

    public void GasButtonState(bool state)
    {
        _isGasPressed = state;
    }

    public void BrakeButtonState(bool state)
    {
        _isBrakePressed = state;
    }

    private void FixedUpdate()
    {
        if (!_alive)
            return;
        
        if (_isGasPressed)
        {
            AddTorqueVehicle(-1);
        }
        else if (_isBrakePressed)
        {
            AddTorqueVehicle(1);
        }
    }

    private void AddTorqueVehicle(int forceDirection)
    {
        backTire.AddTorque(gameSettings.Speed * forceDirection * Time.fixedDeltaTime);
        frontTire.AddTorque(gameSettings.Speed * forceDirection * Time.fixedDeltaTime);
        carRigidBody.AddTorque(gameSettings.CarTorque * forceDirection * Time.fixedDeltaTime);
    }
}
