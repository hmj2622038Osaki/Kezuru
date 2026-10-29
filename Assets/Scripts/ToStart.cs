using UnityEngine;
using UnityEngine.SceneManagement;

public class ToStart: MonoBehaviour
{
	[SerializeField] public float time = 0f;
    void Update()
    {
		time += Time.deltaTime;

        if (time > 3.0f)
		{
			SceneManager.LoadScene("TitleScene");
			time = 0f;
		}
    }
}
