using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
	[SerializeField] GameObject timerText;
	[SerializeField] float time = 30.0f;
	[SerializeField] public List<GameObject> targetObjects;
	private bool isGameOver = false;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		this.timerText = GameObject.Find("Time");
    }

    // Update is called once per frame
    void Update()
    {
		this.time -= Time.deltaTime;
		this.timerText.GetComponent<TextMeshProUGUI>().text = this.time.ToString("F1");

		if (isGameOver) return;
		targetObjects.RemoveAll(item => item == null);

		if (time > 0f && targetObjects.Count == 0)
		{
			isGameOver = true;
			SceneManager.LoadScene("ClearScene");
			return;
		}

		if (time <= 0)
		{
			isGameOver = true;
			SceneManager.LoadScene("GameOverScene");
		}
    }
}
