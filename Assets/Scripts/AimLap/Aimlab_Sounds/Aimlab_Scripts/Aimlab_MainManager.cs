using UnityEngine;
using UnityEngine.SceneManagement;

public class Aimlab_MainManager : MonoBehaviour
{

    public void Starting()
    {
        SceneManager.LoadScene("TetrisScene");
    }


    public void End()
    {
        Application.Quit();
    }


}
