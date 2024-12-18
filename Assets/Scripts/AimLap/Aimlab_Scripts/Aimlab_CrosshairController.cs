using UnityEngine;

public class Aimlab_CrosshairController : MonoBehaviour
{
    public LineRenderer horizontalLine;
    public LineRenderer verticalLine;

    public Aimlab_MouseSensitivity mouseSensitivity;

    [SerializeField] private Aimlab_TargetSpawner targetSpawner;

    [Header("Crosshair Settings")]
    public float length = 1.0f;   
    private float baseThickness = 0.05f;
    private float thickness;           

    [Header("Target Layer")]
    public LayerMask targetLayer;

    private Vector3 crosshairPosition;
    private float crosshairZDepth = 10f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;

        crosshairPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, crosshairZDepth));
        UpdateCrosshairLines();
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity.sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity.sensitivity;

        crosshairPosition += new Vector3(mouseX, mouseY, 0);
        crosshairPosition.z = crosshairZDepth;

        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(crosshairPosition);
        viewportPosition.x = Mathf.Clamp(viewportPosition.x, 0.0f, 1.0f);
        viewportPosition.y = Mathf.Clamp(viewportPosition.y, 0.0f, 1.0f);
        crosshairPosition = Camera.main.ViewportToWorldPoint(new Vector3(viewportPosition.x, viewportPosition.y, crosshairZDepth));

        UpdateCrosshairLines();

        if (Input.GetMouseButtonDown(0))
        {
            CheckHit();
        }
    }

    public void UpdateCrosshairLines()
    {
        thickness = baseThickness * (length / 1.0f);


        horizontalLine.SetPosition(0, crosshairPosition + new Vector3(-length / 2, 0, 0));
        horizontalLine.SetPosition(1, crosshairPosition + new Vector3(length / 2, 0, 0));
        horizontalLine.startWidth = thickness;
        horizontalLine.endWidth = thickness;


        verticalLine.SetPosition(0, crosshairPosition + new Vector3(0, -length / 2, 0));
        verticalLine.SetPosition(1, crosshairPosition + new Vector3(0, length / 2, 0));
        verticalLine.startWidth = thickness;
        verticalLine.endWidth = thickness;
    }

    public void SetCrosshairSize(float newLength)
    {
        length = newLength;
        UpdateCrosshairLines();
    }

    void CheckHit()
    {
        RaycastHit2D hit = Physics2D.Raycast(crosshairPosition, Vector2.zero, 0f, targetLayer);

        if (hit.collider != null)
        {
            Aimlab_Target target = hit.collider.GetComponent<Aimlab_Target>();
            if (target != null)
            {
                targetSpawner.TargetClicked(target.gameObject);
                target.HandleHit();
            }
        }
    }


}
