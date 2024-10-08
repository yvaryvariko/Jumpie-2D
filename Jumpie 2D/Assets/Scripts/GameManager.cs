using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI pressToStartText;
    public Transform lava;

    private void Start()
    {

        pressToStartText.enabled = true;

    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            pressToStartText.enabled = false;
            lava.GetComponent<LavaMove>().enabled = true;
        }
    }



    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
