using System.Collections;
using UnityEngine;

public class CubeFlying : MonoBehaviour
{
    private float lifeTime;
    private float range;

    private Vector3 DestinationPoint;

    private void Start()
    {
        float.TryParse(Spawner.Instance.LifeTimeInput.text, out lifeTime);
        float.TryParse(Spawner.Instance.RangeInput.text, out range);

        DestinationPoint = transform.position + new Vector3(range, 0, 0);

        StartCoroutine(CubeLerping(transform, DestinationPoint, lifeTime));
    }
    public IEnumerator CubeLerping(Transform transform, Vector3 Destination, float time)
    {
        var cubePosition = transform.position;
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / time;
            transform.position = Vector3.Lerp(cubePosition, Destination, t);
            yield return null;
        }
    }
}
