using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ToGame : MonoBehaviour
{
	private void Update()
	{
		if (Mouse.current.leftButton.wasPressedThisFrame)
		{
			SceneManager.LoadScene("GameScene"); // 移動したいゲームシーンの名前を入れ
		}
	}
}
