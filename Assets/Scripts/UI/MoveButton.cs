using UnityEngine;

public abstract class MoveButton : MonoBehaviour 
{
    protected CarLogic CarController;
    
    public void Init(CarLogic carLogic)
    {
        CarController = carLogic;
    }
}
