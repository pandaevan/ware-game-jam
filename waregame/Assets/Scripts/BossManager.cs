using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
[Header("Values")]
  public int SpawnRange;
  public float timePassed;
  [Header("bools")]
  public bool iswatching;
  public bool BossActiveSet;
    public BossTimer mandat;
    public manager Mana;
    public GameObject BT;
    public GameObject BM;
    void Update()
    {
        bossrange();
        BossSpawn();
        BossActiveResetTimer();
        Mana.iswatching = true;
        Mana.IsExposed = true;
    }
    public void BossSpawn()
    {
    if(mandat.iswatching == true)
    {
        BT.SetActive(false);
    }
    }
            private void BossActiveResetTimer()
    {
        timePassed += Time.deltaTime;
        if (timePassed > SpawnRange)
        {
            timePassed = 0;
            BossTimerReset();
        }
    }
        public void bossrange()
    {
      if(BossActiveSet == false)
      {
        SpawnRange = Random.Range(5,10);
        Debug.Log(BossActiveSet);
        BossActiveSet = true;
      }
    }
              public void BossTimerReset()
      {
       Debug.Log("active");
       BossActiveSet = false;
        BT.SetActive(true);
        BM.SetActive(false);
      }
}
