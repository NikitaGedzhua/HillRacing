using UnityEngine.EventSystems;

public class BreakButton : MoveButton, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        CarController.BrakeButtonState(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        CarController.BrakeButtonState(false);
    }
}
