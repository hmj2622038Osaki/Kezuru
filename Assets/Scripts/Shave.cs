using UnityEngine;
using UnityEngine.InputSystem;

public class Shave : MonoBehaviour
{
	GameObject[] iceObjects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		iceObjects = GameObject.FindGameObjectsWithTag("ice");
		//foreach(GameObject ice in iceObjects)
		//{
		//	if (Mouse.current.leftButton.wasPressedThisFrame)
		//	{
		//		Debug.Log("iceが削れた‼‼");
		//		Destroy(ice);
		//	}
		//}
	}

    // Update is called once per frame
    void Update()
    {
		foreach (GameObject ice in iceObjects)
		{
			if (Mouse.current.leftButton.wasPressedThisFrame)
			{
				Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.value);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit, Mathf.Infinity))
				{
					if (hit.collider.CompareTag("ice"))
					{
						Destroy(hit.collider.gameObject);
					}
				}
			}
		}
	}
}
