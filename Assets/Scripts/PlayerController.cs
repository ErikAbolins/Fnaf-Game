using UnityEngine;

public class FNAFCameraController : MonoBehaviour
{
    [Header("Camera Settings")]
    public float mouseSensitivity = 2f;
    public float maxRotationAngle = 60f; // How far left/right the camera can turn
    public bool invertMouseX = false;
    
    [Header("Smooth Movement (Optional)")]
    public bool useSmoothRotation = true;
    public float smoothSpeed = 5f;
    
    private float currentRotationY = 0f;
    private float targetRotationY = 0f;
    
    void Start()
    {
        
        currentRotationY = transform.eulerAngles.y;
        targetRotationY = currentRotationY;
    }
    
    void Update()
    {
        HandleMouseInput();
        
        if (useSmoothRotation)
        {
            ApplySmoothRotation();
        }
        else
        {
            ApplyDirectRotation();
        }
    }
    
    void HandleMouseInput()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        
        if (invertMouseX)
            mouseX = -mouseX;
        
        targetRotationY += mouseX;
        
        targetRotationY = Mathf.Clamp(targetRotationY, -maxRotationAngle, maxRotationAngle);
    }
    
    void ApplySmoothRotation()
    {
        currentRotationY = Mathf.Lerp(currentRotationY, targetRotationY, smoothSpeed * Time.deltaTime);
        
        transform.rotation = Quaternion.Euler(0, currentRotationY, 0);
    }
    
    void ApplyDirectRotation()
    {
        currentRotationY = targetRotationY;
        transform.rotation = Quaternion.Euler(0, currentRotationY, 0);
    }

}