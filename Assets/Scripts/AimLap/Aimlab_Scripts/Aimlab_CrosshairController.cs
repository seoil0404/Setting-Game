using UnityEngine;

public class Aimlab_CrosshairController : MonoBehaviour
{
    public LineRenderer horizontalLine; 
    public LineRenderer verticalLine;   

    [Header("Crosshair Settings")]
    public float length = 1.0f;         
    public float thickness = 0.05f;     

    [Header("Sensitivity Settings")]
    public float sensitivity = 1.0f;  

    [Header("Target Layer")]
    public LayerMask targetLayer;     

    public Aimlab_TargetSpawner targetSpawner; 

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
       
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        
        crosshairPosition += new Vector3(mouseX, mouseY, 0) * sensitivity;

        
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

    void UpdateCrosshairLines()
    {
        
        horizontalLine.SetPosition(0, crosshairPosition + new Vector3(-length / 2, 0, 0)); 
        horizontalLine.SetPosition(1, crosshairPosition + new Vector3(length / 2, 0, 0));  
        horizontalLine.startWidth = thickness;
        horizontalLine.endWidth = thickness;

        
        verticalLine.SetPosition(0, crosshairPosition + new Vector3(0, -length / 2, 0)); 
        verticalLine.SetPosition(1, crosshairPosition + new Vector3(0, length / 2, 0)); 
        verticalLine.startWidth = thickness;
        verticalLine.endWidth = thickness;
    }

    void CheckHit()
    {
        
        RaycastHit2D hit = Physics2D.Raycast(crosshairPosition, Vector2.zero, 0f, targetLayer);

        if (hit.collider != null)
        {
            Debug.Log($"Hit Target: {hit.collider.gameObject.name}");

            
            Aimlab_Target target = hit.collider.GetComponent<Aimlab_Target>();
            if (target != null)
            {
                target.HandleHit(); 
                targetSpawner.TargetClicked(hit.collider.gameObject); 
            }
        }
    }
}
