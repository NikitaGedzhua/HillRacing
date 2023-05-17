using UnityEngine.EventSystems;

public class GasButton : MoveButton, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        CarController.GasButtonState(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        CarController.GasButtonState(false);
    }
}
