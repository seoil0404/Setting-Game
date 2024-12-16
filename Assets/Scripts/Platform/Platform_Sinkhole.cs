using UnityEngine;

public class Platform_Sinkhole : MonoBehaviour
{
    [SerializeField] private SinkholeState sinkHoleState;

    [Header("Split")]
    [SerializeField] private GameObject leftObject;
    [SerializeField] private GameObject rightObject;

    [Header("Fall")]
    [SerializeField] private GameObject fallObject;

    [System.Serializable]
    public enum SinkholeState
    {
        Split, Fall
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            switch(sinkHoleState)
            {

            }
        }
    }
}
