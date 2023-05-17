using UnityEngine;

[CreateAssetMenu(menuName = "Settings", order = 51)]
public class GameSettings : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private float carTorque;

    public float Speed => speed;
    public float CarTorque => carTorque;
}
