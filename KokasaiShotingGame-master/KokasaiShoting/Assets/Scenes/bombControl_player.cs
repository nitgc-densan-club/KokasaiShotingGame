using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombControl_player : MonoBehaviour
{

	public float deleteTime = 7.0f;
	public Rigidbody rb;
	SphereCollider sc;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		sc = GetComponent<SphereCollider>();
		rb.AddForce(0, 13, 13, ForceMode.Impulse);
		Destroy(gameObject, deleteTime);
		StartCoroutine("ChangeCollider");
	}


	// Update is called once per frame
	void Update()
	{

	}

	//当たり判定を時間経過で変更
	IEnumerator ChangeCollider()
	{
		yield return new WaitForSeconds(5.0f);
		sc.radius = 10.0f;
	}
}



