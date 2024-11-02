using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashComponent : MonoBehaviour
{
    [SerializeField] private Material flashMaterial;
    [SerializeField] private float duration;
    [SerializeField] private Color flashColor;

    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    private Coroutine flashRoutine; 
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;

        flashMaterial = new Material(flashMaterial);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Flash() {
        if (flashRoutine != null) 
        {
            StopCoroutine(flashRoutine);
        }

        flashRoutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine() 
    {
        spriteRenderer.material = flashMaterial;
        flashMaterial.color = flashColor;
        yield return new WaitForSeconds(duration);
        spriteRenderer.material = originalMaterial;
        flashRoutine = null;
    }
}
