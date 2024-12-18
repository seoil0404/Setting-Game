using UnityEngine;

public class Platform_Flag : MonoBehaviour
{
    [SerializeField] private Platform_GameManager gameManager;
    [SerializeField] private Transform player;
    [SerializeField] private Platform_SettingData settingData;
    [SerializeField] private Animator flagAnimator;

    private readonly float flagRunDistance = 3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            gameManager.Victory();
        }
    }

    private void Update()
    {
        if(player.transform.position.x + flagRunDistance > transform.position.x && settingData.IsGoalRun)
        {
            transform.position = new Vector3(player.transform.position.x + flagRunDistance, transform.position.y, transform.position.z);
            flagAnimator.SetBool("IsRun", true);
        }
        else
        {
            flagAnimator.SetBool("IsRun", false);
        }
    }
}
