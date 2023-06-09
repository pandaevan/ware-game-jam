using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    private int RandomX;
    [SerializeField] private int Delay;
    private Vector3 StarPositions;

    public GameObject Prefab;
    void Start()
    {
        StartCoroutine(Timer(3));
    }
    void Create()
    {
        GameObject PrefabI = Instantiate(Prefab,StarPositions,Quaternion.identity);
    }
    IEnumerator Timer(int x)
    {
        int StarAmount = Random.Range(2,5);
        yield return new WaitForSeconds(x);
        for (int i = 0; i<StarAmount; i++)
        {
            RandomX = Random.Range(-7,7);
            StarPositions = new Vector3(RandomX,6,0);
            Create();
            yield return new WaitForSeconds(Delay);

        }
    }
}
