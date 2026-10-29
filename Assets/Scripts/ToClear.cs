using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToClear : MonoBehaviour
{
	[Header("設定項目")]
	[SerializeField] public float timeLimit = 30.0f;          // 制限時間
	[SerializeField] public List<GameObject> targetObjects;   // 消える対象のオブジェクト達

	[Header("UI連携")]
	[SerializeField] public TextMeshProUGUI timerText;

	private bool isGameOver = false;

	void Update()
	{
		if (isGameOver) return;

		targetObjects.RemoveAll(item => item == null);

		if (targetObjects.Count == 0)
		{
			isGameOver = true;
			SceneManager.LoadScene("ClearScene");
			return;
		}

		if (timeLimit <= 0)
		{
			isGameOver = true;
			SceneManager.LoadScene("GameOverScene");
		}
	}
}
