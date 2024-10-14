using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashEffect : MonoBehaviour
{
    [Tooltip("Material for Flash Effect")]
    [SerializeField] private Material flashMaterial;
    [Tooltip("Flash Effect duration")]
    [SerializeField] private float duration;

    private SpriteRenderer spriteRenderer;
    private Material originalMaterial; //A cual debe volver
    private Coroutine flashRoutine; //Ref a la corutina actual

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material; //Guarda el material base.

        
    }
    public void Flash()
    {
        if(flashRoutine != null)
        {
            //Si ya se está ejecutando, lo cancela y arranca de nuevo
            StopCoroutine(flashRoutine);
        }
        flashRoutine = StartCoroutine(FlashRoutine()); //guarda ref de la actual rutina
    }
    private IEnumerator FlashRoutine()
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(duration);

        spriteRenderer.material = originalMaterial;
        flashRoutine = null;//termino
    }
    public void CancelFlash()
    {
        if (flashRoutine != null)
        {
            //Si ya se está ejecutando, lo cancela y arranca de nuevo
            StopCoroutine(flashRoutine);
            spriteRenderer.material = originalMaterial;
            flashRoutine = null;//termino
        }
    }
}
