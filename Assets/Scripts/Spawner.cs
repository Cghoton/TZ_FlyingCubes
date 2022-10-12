using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject CubePrefab;

    [SerializeField]
    private InputField SpawnCooldownInput;

    [SerializeField]
    public InputField LifeTimeInput;
    [SerializeField]
    public InputField RangeInput;

    public static Spawner Instance;

    private void Start()
    {
        Instance = this;
        StartCoroutine(SpawnCube());
    }
    IEnumerator SpawnCube()
    {
        while (true)
        {
            float.TryParse(LifeTimeInput.text, out float _lifetime);
            float.TryParse(SpawnCooldownInput.text, out float _cooldown);

            if (_cooldown < 0.5f)
                _cooldown = 1f;
            
            Destroy(Instantiate(CubePrefab, transform.position, transform.rotation), _lifetime);

            yield return new WaitForSeconds(_cooldown);
        }
    }
}
