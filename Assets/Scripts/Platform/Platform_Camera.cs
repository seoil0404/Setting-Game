using UnityEngine;

public class Platform_Camera : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Platform_SettingData settingData;

    private void Update()
    {
        if(settingData.IsCameraFollow)
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
    }
}
