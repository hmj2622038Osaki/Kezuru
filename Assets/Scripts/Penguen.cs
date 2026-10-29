using System.Dynamic;
using UnityEngine;

public class Penguin : MonoBehaviour
{
	[Header("移動範囲の設定")]
	[SerializeField] private float minX = -7f;
	[SerializeField] private float maxX = 7f;
	[SerializeField] private float minZ = -7f;
	[SerializeField] private float maxZ = 7f;

	[Header("移動パラメータ")]
	[SerializeField] private float moveSpeed = 5f;
	[SerializeField] private float waitTime = 1f;

	private Vector3 targetPosition;
	private float timer;

	void Start()
	{
		GetNextTargetPosition();
	}

	void Update()
	{
		// 目的地へ向かって移動
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

		// 目的地に到着したら一定時間待ってから次の目的地を決定
		if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
		{
			timer += Time.deltaTime;
			if (timer >= waitTime)
			{
				GetNextTargetPosition();
				timer = 0f;
			}
		}

		// y軸が-3以下で消える
		if (transform.position.y <= -3)
		{
			Destroy(gameObject);
		}
	}

	private void GetNextTargetPosition()
	{
		float randomX = Random.Range(minX, maxX);
		float randomZ = Random.Range(minZ, maxZ);
		targetPosition = new Vector3(randomX, transform.position.y, randomZ);
	}
}