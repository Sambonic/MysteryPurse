using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenSpikes : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        Hide();
    }

    public void Reveal()
    {
        GameObject parentGroup = GameObject.Find("Trap 2: Ground Spikes");
        if (parentGroup != null)
        {
            foreach (Transform child in parentGroup.transform)
            {
                // Enable each child's SpriteRenderer (or MeshRenderer) component
                SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.enabled = true;
                }
            }
        }
    }
    public void Hide()
    {
        GameObject parentGroup = GameObject.Find("Trap 2: Ground Spikes");
        if (parentGroup != null)
        {
            foreach (Transform child in parentGroup.transform)
            {
                // Enable each child's SpriteRenderer (or MeshRenderer) component
                SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.enabled = false;
                }
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
