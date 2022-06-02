using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace MJ
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Transform MainPlayer;
        public List<Transform> Platforms;
        private int PlatformNumber;
        [SerializeField] private RectTransform GameWin;
        [SerializeField] private RectTransform TapToStart;
        [SerializeField] private GameObject EndCelebs;
        private EnemyManager[] Enenmis;
        
        private void Awake()
        {
            Enenmis = GameObject.FindObjectsOfType<EnemyManager>();
            print(Enenmis.Length);
        }
        public IEnumerator LevelIncremnet(float TimeToTake)
        {
            yield return new WaitForSeconds(TimeToTake);
            if (PlatformNumber == Enenmis.Length)
            {
                Debug.Log("Win");
                EndCelebs.SetActive(true);
                GameWin.DOAnchorPosY(0, 0.75f, false);
            }
            if (PlatformNumber <= Platforms.Count-1)
            {
                MainPlayer.DOMove(Platforms[PlatformNumber].position,0.5f,false);
                PlatformNumber++;
                Debug.Log(PlatformNumber);

            }
        }
        public void GameStart()
        {
            TapToStart.gameObject.SetActive(false);
            StartCoroutine(LevelIncremnet(0.25f));
        }

    }
}
