using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class WalkToShop : MonoBehaviour
{
	public Transform target;
	private Animator animation;
	private SpriteRenderer spriteRenderer;
	private Vector3 start;
	// Use this for initialization
	void Start ()
	{
		spriteRenderer = transform.GetComponent<SpriteRenderer>();
		animation = transform.GetComponent<Animator>();
		start = transform.position;
	}


	public void WalkToPlayer()
	{

			WalkUp();
		
	}

	private void WalkUp()
	{
		animation.Play("walk_up");
		transform.DOMoveY(target.transform.position.y, 5f).OnComplete(WalkLeft);
	}
	private void WalkLeft()
	{
		animation.Play("walk_left");
		transform.DOMoveX(target.transform.position.x + spriteRenderer.bounds.size.x, 1f).OnComplete(idle);
	}

	private void idle()
	{
		animation.Play("idle_left");
	}

	public void ResetPosition()
	{
		transform.position = start;
	}
}
