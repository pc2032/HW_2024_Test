using System.Collections;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab;
    public float minDestroyTime = 4f;
    public float maxDestroyTime = 5f;
    public float spawnDelay = 2.5f;
    public float animDuration = 0.1f;

    private GameObject lastGround;

    void Start()
    {

        StartCoroutine(SpawnManage());
    }

    private IEnumerator SpawnManage()
    {
        lastGround = SpawnGround(Vector3.zero);

        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

            Vector3 spawnPos = GetNextSpawnPos();

            GameObject newGround = SpawnGround(spawnPos);

            float destroyTime = Random.Range(minDestroyTime, maxDestroyTime);
            StartCoroutine(ScaleAndDestroy(lastGround, destroyTime));

            lastGround = newGround;
        }
    }

    private GameObject SpawnGround(Vector3 pos)
    {
        GameObject newGround = Instantiate(groundPrefab, pos, Quaternion.identity);
        StartCoroutine(ScaleUp(newGround.transform));
        return newGround;
    }

    private Vector3 GetNextSpawnPos()
    {
        Vector3 lastPos = lastGround.transform.position;
        Vector3 lastScale = lastGround.transform.localScale;

        if (Random.value > 0.5f)
        {
            return new Vector3(lastPos.x, lastPos.y, lastPos.z + lastScale.z);
        }
        else
        {
            return new Vector3(lastPos.x + lastScale.x, lastPos.y, lastPos.z);
        }
    }

    private IEnumerator ScaleUp(Transform target)
    {
        Vector3 initialScale = Vector3.zero;
        Vector3 finalScale = target.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < animDuration)
        {
            target.localScale = Vector3.Lerp(initialScale, finalScale, elapsedTime / animDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        target.localScale = finalScale;
    }

    private IEnumerator ScaleAndDestroy(GameObject target, float delay)
    {
        yield return new WaitForSeconds(delay);

        Transform targetTransform = target.transform;
        Vector3 initialScale = targetTransform.localScale;
        Vector3 finalScale = Vector3.zero;
        float elapsedTime = 0f;

        while (elapsedTime < animDuration)
        {
            targetTransform.localScale = Vector3.Lerp(initialScale, finalScale, elapsedTime / animDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(target);
    }
}