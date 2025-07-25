using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        FindFirstObjectByType<PlayerMovement>().enabled = false;
        FindFirstObjectByType<Ground>().gameObject.GetComponent<BoxCollider>().material = null;
        Invoke("RestartLevel", 2f);
        Debug.Log("Game Over");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
