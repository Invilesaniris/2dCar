using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private bool isPackagePickup = false;
    [SerializeField] public float DestroyDelay=0.5f;
    [SerializeField] public Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] public Color32 noPackageColor = new Color32(1, 1, 1, 1);
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision with the following information:");
        Debug.Log(collision.otherRigidbody);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Customer" && isPackagePickup)
        {
            Debug.Log("Bumped into customer");
            isPackagePickup = false;
            spriteRenderer.color = noPackageColor;
        }
        else if (collision.tag == "Package" && !isPackagePickup)
        {
            Debug.Log("Bumped into package");
            isPackagePickup = true;
            Destroy(collision.gameObject, DestroyDelay);
            SpriteRenderer otherSpriteRenderer= collision.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = otherSpriteRenderer.color;
        }
    }

}
