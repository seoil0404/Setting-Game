using UnityEngine;

public class Aimlab_CrosshairController : MonoBehaviour
{
    public LineRenderer horizontalLine; // 가로선
    public LineRenderer verticalLine;   // 세로선

    [Header("Crosshair Settings")]
    public float length = 1.0f;         // 조준선 길이
    public float thickness = 0.05f;     // 조준선 두께

    [Header("Sensitivity Settings")]
    public float sensitivity = 1.0f;   // 마우스 감도

    [Header("Target Layer")]
    public LayerMask targetLayer;      // 타겟 레이어를 설정

    private Vector3 crosshairPosition;  // 크로스헤어의 현재 중심 위치
    private float crosshairZDepth = 10f; // 카메라로부터 크로스헤어의 Z 거리

    void Start()
    {
        // 마우스 커서 숨기기
        Cursor.lockState = CursorLockMode.Confined; // 마우스를 화면 안으로 고정
        Cursor.visible = false; // 마우스 커서 숨기기

        // 크로스헤어의 초기 위치를 화면 중앙으로 설정
        crosshairPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, crosshairZDepth));
        UpdateCrosshairLines();
    }

    void Update()
    {
        // 마우스 이동 값 가져오기
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // 마우스 이동값에 감도를 곱하여 크로스헤어 위치 계산
        crosshairPosition += new Vector3(mouseX, mouseY, 0) * sensitivity;

        // Z값 고정
        crosshairPosition.z = crosshairZDepth;

        // 화면 경계 안으로 제한
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(crosshairPosition);
        viewportPosition.x = Mathf.Clamp(viewportPosition.x, 0.0f, 1.0f);
        viewportPosition.y = Mathf.Clamp(viewportPosition.y, 0.0f, 1.0f);
        crosshairPosition = Camera.main.ViewportToWorldPoint(new Vector3(viewportPosition.x, viewportPosition.y, crosshairZDepth));

        // 크로스헤어 위치를 Line Renderer로 업데이트
        UpdateCrosshairLines();

        // 마우스 클릭 처리
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 클릭
        {
            CheckHit();
        }
    }

    void UpdateCrosshairLines()
    {
        // 가로선 위치 설정
        horizontalLine.SetPosition(0, crosshairPosition + new Vector3(-length / 2, 0, 0)); // 왼쪽 끝
        horizontalLine.SetPosition(1, crosshairPosition + new Vector3(length / 2, 0, 0));  // 오른쪽 끝
        horizontalLine.startWidth = thickness;
        horizontalLine.endWidth = thickness;

        // 세로선 위치 설정
        verticalLine.SetPosition(0, crosshairPosition + new Vector3(0, -length / 2, 0)); // 아래 끝
        verticalLine.SetPosition(1, crosshairPosition + new Vector3(0, length / 2, 0));  // 위 끝
        verticalLine.startWidth = thickness;
        verticalLine.endWidth = thickness;
    }

    void CheckHit()
    {
        // 크로스헤어 중심에서 Raycast 발사
        RaycastHit2D hit = Physics2D.Raycast(crosshairPosition, Vector2.zero, 0f, targetLayer);

        if (hit.collider != null)
        {
            Debug.Log($"Hit: {hit.collider.gameObject.name}");
            // 타겟과 충돌 시 조준선 숨기기
            HideCrosshair();
        }
    }

    void HideCrosshair()
    {
        // Line Renderer 비활성화
        horizontalLine.enabled = false;
        verticalLine.enabled = false;

        // 필요 시 추가 동작 (예: 타겟 파괴)
    }

    public void ShowCrosshair()
    {
        // Line Renderer 활성화
        horizontalLine.enabled = true;
        verticalLine.enabled = true;
    }
}
