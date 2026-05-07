using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CorkStretch : MonoBehaviour
{
    [SerializeField] private BottleController bottle = null;

    [Header("Stretch")]
    [SerializeField] private Transform corkVisual = null ;
    [SerializeField] private float stretchMultiplier = 0.5f;

    [Header("Break")]
    [SerializeField] private float breakThreshold = 2.5f;
    private float distanceBetweenCorkAndBottle = 0;

    private Vector3 originalScale = new Vector3();
    private bool isBroken = false;


    

    private void Start()
    {
        originalScale = corkVisual.localScale;
    }

    private void Update()
    {
        if (isBroken) return;

        distanceBetweenCorkAndBottle = bottle.GetCurrentDistance() ;

        ApplyStretch(distanceBetweenCorkAndBottle);
        CheckBreak(distanceBetweenCorkAndBottle);
    }

    private void ApplyStretch(float distance)
    {
        Vector2 dir = (bottle.transform.position - transform.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        corkVisual.rotation = Quaternion.Euler(0, 0, angle+90);

        float stretch = 1 + distance * stretchMultiplier;

        corkVisual.localScale = new Vector3(
     originalScale.x ,
     originalScale.y * stretch,
     originalScale.z
 );
    }

    private void CheckBreak(float distance)
    {
        Debug.Log("this is disntace" + distance);
        if (distance >= breakThreshold)
        {
            Break();
        }
    }

    private void Break()
    {
        isBroken = true;
        bottle.ChangeBrokenBool();
        Debug.Log("POP!");
        StartCoroutine(SnapScale(corkVisual, originalScale, 0.2f));
        StartCoroutine(ReloadScene());
        bottle.transform.position = new Vector2(-0.5f,-1.6f);

    }

    IEnumerator SnapScale(Transform target, Vector3 targetScale, float duration = 0.25f)
    {
        Vector3 startScale = target.localScale;

        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;

            float t = time / duration;

            // EaseOutBack curve (snap effect)
            float overshoot = 1.70158f;
            float easedT = 1 + overshoot * Mathf.Pow(t - 1, 3) + overshoot * Mathf.Pow(t - 1, 2);

            target.localScale = Vector3.LerpUnclamped(startScale, targetScale, easedT);

            yield return null;
        }

        target.localScale = targetScale;
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}