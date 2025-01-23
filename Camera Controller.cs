using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Follow Settings")]
    public Transform followAt;
    [SerializeField, Range(0.1f, 10f)]
    private float _followSmoothness = 2.5f;

    [Header("Pan Settings")]
    [Tooltip("Enable or disable X-axis pan limits")]
    public bool enablePanLimitX = true;
    [Tooltip("Minimum and maximum X coordinates for panning")]
    public Vector2 panLimitX = new Vector2(-10f, 10f);
    [Tooltip("Enable or disable Z-axis pan limits")]
    public bool enablePanLimitZ = true;
    [Tooltip("Minimum and maximum Z coordinates for panning")]
    public Vector2 panLimitZ = new Vector2(-10f, 10f);
    [SerializeField, Range(1f, 20f)]
    private float _panSpeed = 5f;

    [Header("Rotation Settings")]
    [SerializeField, Range(1f, 20f)]
    private float _rotationSpeed = 5f;

    [Header("Zoom Settings")]
    [SerializeField, Range(1f, 100f)]
    private float _zoomSpeed = 6f;
    [SerializeField, Range(0.1f, 10f)]
    private float _zoomSmoothness = 5f;
    [Tooltip("Minimum zoom level (camera orthographic size)")]
    public float minZoom = 5f;
    [Tooltip("Maximum zoom level (camera orthographic size)")]
    public float maxZoom = 10f;

    private float _currentZoom;
    private Camera _camera;
    private float _targetYaw = 0f;
    private Vector3 _targetPosition;
    private Transform _transform;

    // Properties with validation
    public float FollowSmoothness
    {
        get => _followSmoothness;
        set => _followSmoothness = Mathf.Clamp(value, 0.1f, 10f);
    }

    public float PanSpeed
    {
        get => _panSpeed;
        set => _panSpeed = Mathf.Clamp(value, 1f, 20f);
    }

    public float RotationSpeed
    {
        get => _rotationSpeed;
        set => _rotationSpeed = Mathf.Clamp(value, 1f, 20f);
    }

    public float ZoomSpeed
    {
        get => _zoomSpeed;
        set => _zoomSpeed = Mathf.Clamp(value, 1f, 100f);
    }

    public float ZoomSmoothness
    {
        get => _zoomSmoothness;
        set => _zoomSmoothness = Mathf.Clamp(value, 0.1f, 10f);
    }

    void Awake()
    {
        _camera = GetComponentInChildren<Camera>();
        _transform = transform;
        _currentZoom = minZoom;
        _targetPosition = _transform.position;
    }

    void Update()
    {
        HandleFollowing();
        HandlePanning();
        HandleZooming();
        HandleRotation();
    }

    private void HandleFollowing()
    {
        if (followAt != null)
        {
            _targetPosition = followAt.position;
        }

        _transform.position = Vector3.Lerp(_transform.position, _targetPosition, FollowSmoothness * Time.deltaTime);
    }

    private void HandlePanning()
    {
        if (followAt != null) return;

        Vector3 move = Quaternion.Euler(0, _camera.transform.eulerAngles.y, 0) * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _targetPosition += move * (PanSpeed * Time.deltaTime);

        if (enablePanLimitX)
            _targetPosition.x = Mathf.Clamp(_targetPosition.x, panLimitX.x, panLimitX.y);
        if (enablePanLimitZ)
            _targetPosition.z = Mathf.Clamp(_targetPosition.z, panLimitZ.x, panLimitZ.y);
    }

    private void HandleZooming()
    {
        _currentZoom = Mathf.Clamp(_currentZoom - Input.mouseScrollDelta.y * ZoomSpeed * Time.deltaTime, minZoom, maxZoom);
        _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, _currentZoom, ZoomSmoothness * Time.deltaTime);
    }

    private void HandleRotation()
    {
        if (Input.GetMouseButton(1))
        {
            _targetYaw += Input.GetAxis("Mouse X") * RotationSpeed;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            _targetYaw = Mathf.Round(_targetYaw / 45f) * 45f;
        }

        _transform.rotation = Quaternion.Slerp(_transform.rotation, Quaternion.Euler(0f, _targetYaw, 0f), RotationSpeed * Time.deltaTime);
    }
}

