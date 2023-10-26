using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen3dmaxDestroyer : MonoBehaviour
{
    [SerializeField] private ParticleSystem destroyEffect;
    [SerializeField] private float deltaTimeDestroy;
    private Image[] _maxs3d;

    private void Awake()
    {
        _maxs3d = new Image[transform.childCount];
        for (int i = 0; i < _maxs3d.Length; i++)
            _maxs3d[i] = transform.GetChild(i).GetComponent<Image>();
        StartCoroutine(max3dDestroyer());
    }

    private IEnumerator max3dDestroyer()
    {
        yield return new WaitForSeconds(deltaTimeDestroy);
        foreach (Image max3dPic in _maxs3d)
        {
            ParticleSystem spawnedDestroyEffect = Instantiate(destroyEffect, max3dPic.transform.position, Quaternion.identity);
            spawnedDestroyEffect.Play();
            max3dPic.enabled = false;
        }
    }
}
