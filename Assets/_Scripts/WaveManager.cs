using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WaveManager : MonoBehaviour {

    [SerializeField]
    private GameObject prefEnemy;
    [SerializeField]
    private GameObject prefEnemy2;
    [SerializeField]
    private GameObject flag;
    private float totalAmountOFEnemies = 2;
    public float waveCounter = 0;
    public float coinCounter = 100;
    private float z = 0;
    [SerializeField]
    private Text waveCounterText;
    [SerializeField]
    private Text coinCounterText;
    void Start() {
        UpdateWaveUI();
        UpdateCoinUI();

    }
    void UpdateWaveUI()
    {
        waveCounterText.text = "Wave: " + waveCounter;
        
    }
    public void UpdateCoinUI()
    {
        coinCounterText.text = "X " + coinCounter;
    }

    void ProduceWave()
    {
        if(totalAmountOFEnemies <50)
        {
            totalAmountOFEnemies += waveCounter;
        }
        
        z -= totalAmountOFEnemies;
        StartCoroutine(ProduceEnemy());
        
    }
    IEnumerator ProduceEnemy()
    {
        if(flag != null)
        {
            float y = Random.Range(-10f,0f);
            float x;
            float xTemp = Random.Range(0f, 2f);
            if(xTemp >= 1)
            {
                x = -10;
            }
            else
            {
                x = 10;
            }
            Vector3 startPosition = new Vector3(x, y, 0.5f);
            if(Random.Range(0f,1f) >= 0.7f)
            {
                GameObject temp = Instantiate(prefEnemy, startPosition, Quaternion.identity) as GameObject;
            }
            else
            {
                GameObject temp = Instantiate(prefEnemy2, startPosition, Quaternion.identity) as GameObject;
            }
            
        }

        float t = Random.Range(0f,1f);
        yield return new WaitForSeconds(t);
        z++;
        
        if (z < 0)
        {
            
            StartCoroutine(ProduceEnemy());
        }
    }

    void OnMouseDown()
    {
            waveCounter++;
            UpdateWaveUI();
            ProduceWave();
            Debug.Log("next wave!");
    }
    void OnMouseEnter()
    {
        this.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }
    void OnMouseExit()
    {
        this.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
