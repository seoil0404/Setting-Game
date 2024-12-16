using UnityEngine;

public class Aimlab_CrosshairController : MonoBehaviour
{
    public LineRenderer horizontalLine; // ���μ�
    public LineRenderer verticalLine;   // ���μ�

    [Header("Crosshair Settings")]
    public float length = 1.0f;         // ���ؼ� ����
    public float thickness = 0.05f;     // ���ؼ� �β�

    [Header("Sensitivity Settings")]
    public float sensitivity = 1.0f;   // ���콺 ����

    [Header("Target Layer")]
    public LayerMask targetLayer;      // Ÿ�� ���̾ ����

    private Vector3 crosshairPosition;  // ũ�ν������ ���� �߽� ��ġ
    private float crosshairZDepth = 10f; // ī�޶�κ��� ũ�ν������ Z �Ÿ�

    void Start()
    {
        // ���콺 Ŀ�� �����
        Cursor.lockState = CursorLockMode.Confined; // ���콺�� ȭ�� ������ ����
        Cursor.visible = false; // ���콺 Ŀ�� �����

        // ũ�ν������ �ʱ� ��ġ�� ȭ�� �߾����� ����
        crosshairPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, crosshairZDepth));
        UpdateCrosshairLines();
    }

    void Update()
    {
        // ���콺 �̵� �� ��������
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // ���콺 �̵����� ������ ���Ͽ� ũ�ν���� ��ġ ���
        crosshairPosition += new Vector3(mouseX, mouseY, 0) * sensitivity;

        // Z�� ����
        crosshairPosition.z = crosshairZDepth;

        // ȭ�� ��� ������ ����
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(crosshairPosition);
        viewportPosition.x = Mathf.Clamp(viewportPosition.x, 0.0f, 1.0f);
        viewportPosition.y = Mathf.Clamp(viewportPosition.y, 0.0f, 1.0f);
        crosshairPosition = Camera.main.ViewportToWorldPoint(new Vector3(viewportPosition.x, viewportPosition.y, crosshairZDepth));

        // ũ�ν���� ��ġ�� Line Renderer�� ������Ʈ
        UpdateCrosshairLines();

        // ���콺 Ŭ�� ó��
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� Ŭ��
        {
            CheckHit();
        }
    }

    void UpdateCrosshairLines()
    {
        // ���μ� ��ġ ����
        horizontalLine.SetPosition(0, crosshairPosition + new Vector3(-length / 2, 0, 0)); // ���� ��
        horizontalLine.SetPosition(1, crosshairPosition + new Vector3(length / 2, 0, 0));  // ������ ��
        horizontalLine.startWidth = thickness;
        horizontalLine.endWidth = thickness;

        // ���μ� ��ġ ����
        verticalLine.SetPosition(0, crosshairPosition + new Vector3(0, -length / 2, 0)); // �Ʒ� ��
        verticalLine.SetPosition(1, crosshairPosition + new Vector3(0, length / 2, 0));  // �� ��
        verticalLine.startWidth = thickness;
        verticalLine.endWidth = thickness;
    }

    void CheckHit()
    {
        // ũ�ν���� �߽ɿ��� Raycast �߻�
        RaycastHit2D hit = Physics2D.Raycast(crosshairPosition, Vector2.zero, 0f, targetLayer);

        if (hit.collider != null)
        {
            Debug.Log($"Hit: {hit.collider.gameObject.name}");
            // Ÿ�ٰ� �浹 �� ���ؼ� �����
            HideCrosshair();
        }
    }

    void HideCrosshair()
    {
        // Line Renderer ��Ȱ��ȭ
        horizontalLine.enabled = false;
        verticalLine.enabled = false;

        // �ʿ� �� �߰� ���� (��: Ÿ�� �ı�)
    }

    public void ShowCrosshair()
    {
        // Line Renderer Ȱ��ȭ
        horizontalLine.enabled = true;
        verticalLine.enabled = true;
    }
}
