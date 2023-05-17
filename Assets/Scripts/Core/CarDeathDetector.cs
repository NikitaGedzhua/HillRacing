using UnityEngine;
using UnityEngine.U2D;

public class CarDeathDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out SpriteShapeRenderer ground))
            this.OnEvent(eEventType.GroundTouched);
    }
}
