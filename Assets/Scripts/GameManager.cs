using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameDataSO data;

    private void Update()
    {
        Physics.gravity = new Vector3(data.Acceleration.x, data.Acceleration.y + Physics.gravity.y, data.Acceleration.z);
    }
}
