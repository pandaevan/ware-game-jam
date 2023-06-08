using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTimer : MonoBehaviour
{
    public GameObject BM;
     [Header("Values")]
  public int bossspawntimer;
  public float timePassed;
  [Header("bools")]
  public bool iswatching;
  public bool BossTimerSet;
  public manager Mana;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        BossActiveResetTimer();
        bossrange();
         Mana.iswatching = false;
         Mana.IsExposed = false;
    }
        private void BossActiveResetTimer()
    {
        timePassed += Time.deltaTime;
        if (timePassed > bossspawntimer)
        {
            timePassed = 0;
            BossTimerReset();
        }
    }
        public void bossrange()
    {
      if(BossTimerSet == false)
      {
        bossspawntimer = Random.Range(10,30);
        Debug.Log(BossTimerSet);
        BossTimerSet = true;
      }
    }
              public void BossTimerReset()
      {
       Debug.Log("active");
       BossTimerSet = false;
       iswatching = true;
       BM.SetActive(true);
      }
}
