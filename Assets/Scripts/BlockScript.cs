using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour {

	public bool touched;

    public int length;

    public Sprite left;
    public Sprite center;
    public Sprite right;
    public SpriteRenderer sr;

	private Animator myAnimator;

    public Sprite sprite1; // Drag your first sprite here
    public Sprite sprite2; // Drag your second sprite here

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = sprite1; // set the sprite to sprite1
    }

    void Update()
    {
        myAnimator.SetBool("Touched", touched);
        if (Input.GetKeyDown(KeyCode.Space)) // If the space bar is pushed down
        {
            ChangeTheDamnSprite(); // call method to change sprite
        }
    }

    void ChangeTheDamnSprite()
    {
        if (spriteRenderer.sprite == sprite1) // if the spriteRenderer sprite = sprite1 then change to sprite2
        {
            spriteRenderer.sprite = sprite2;
        }
        else
        {
            spriteRenderer.sprite = sprite1; // otherwise change it back to sprite1
        }
    }

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			touched = true;
		}
	}
}
