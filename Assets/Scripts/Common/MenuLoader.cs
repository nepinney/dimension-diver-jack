using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoader : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

}
