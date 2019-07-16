#pragma warning disable 0649
using UnityEngine;

public class TargetFollow : MonoBehaviour
{
	[SerializeField] private Transform targetToFollow;
	[SerializeField] private float dampTime = 0.15f;
	
    private Vector3 velocity = Vector3.zero;

	public void FixedUpdate()
	{
		Vector3 destination = targetToFollow.position;
		
		Transform t = transform;
		Vector3 pos = t.position;

		destination.y = pos.y;
		destination.z = pos.z;
        transform.position = Vector3.SmoothDamp(pos, destination, ref velocity, dampTime);
    }
}
