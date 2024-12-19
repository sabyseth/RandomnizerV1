using UnityEngine;

public struct CameraInput
{
    public Vector2 Look;
}

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float sensitivity = 0.1f;
    private Vector3 _eulerAngles;
    public float maxPitch = 80f;

    public void Initialize(Transform target)
    {
        transform.position = target.position;
        transform.eulerAngles = _eulerAngles = target.eulerAngles;
        
    }

    public void UpdateRotation(CameraInput input)
    {
        _eulerAngles += new Vector3(-input.Look.y, input.Look.x) * sensitivity;
        transform.eulerAngles = Vector3.ClampMagnitude(_eulerAngles, 100f);
    }

    public void UpdatePosition(Transform target)
    {
        transform.position = target.position;
    }
}
