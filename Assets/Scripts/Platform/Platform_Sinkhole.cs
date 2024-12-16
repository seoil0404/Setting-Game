using UnityEngine;
using UnityEngine.UIElements;

public class Platform_Sinkhole : MonoBehaviour
{
    [SerializeField] private SinkholeState sinkHoleState;

    [Header("Split")]
    [SerializeField] private GameObject leftObject;
    [SerializeField] private GameObject rightObject;
    private Vector3 leftToPos;
    private Vector3 rightToPos;
    [SerializeField] private float splitRate;
    [SerializeField] private float splitSpeed;

    [Header("Fall")]
    [SerializeField] private GameObject fallObject;
    private Vector3 fallToPos;
    [SerializeField] private float fallRate;
    [SerializeField] private float fallSpeed;

    [System.Serializable]
    public enum SinkholeState
    {
        Split, Fall
    }

    private void Awake()
    {
        leftToPos = leftObject.transform.position;
        rightToPos = rightObject.transform.position;
        fallToPos = fallObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            switch(sinkHoleState)
            {
                case SinkholeState.Split:
                    leftToPos = new Vector3(-splitRate, leftObject.transform.position.y, leftObject.transform.position.z);
                    rightToPos = new Vector3(splitRate, rightObject.transform.position.y, rightObject.transform.position.z);
                    break;
                case SinkholeState.Fall:
                    fallToPos = new Vector3(fallObject.transform.position.x, -fallRate, fallObject.transform.position.z);
                    break;
            }
        }
    }

    private void Update()
    {
        leftObject.transform.position = Vector3.Lerp(leftObject.transform.position, leftToPos, splitSpeed);
        rightObject.transform.position = Vector3.Lerp(rightObject.transform.position, rightToPos, splitSpeed);
        fallObject.transform.position = Vector3.Lerp(fallObject.transform.position, fallToPos, fallSpeed);
    }
}
