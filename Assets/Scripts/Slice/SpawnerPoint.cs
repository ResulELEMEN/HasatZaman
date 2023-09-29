
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FruitCreate
{
   public Sprite sprite;
   public Color color1;
   public Color color2;
}
public class SpawnerPoint : MonoBehaviour
{
    public List<FruitCreate> fruitCreates;
    public RectTransform left;
    Vector3 LeftVektor;
    Vector3 targetVektor;

    //launch
    public List<GameObject> fruits;
    public List<Sprite> fruitsSprite;
    public float minForce = 5f; // Minimum fýrlatma gücü
    public float maxForce = 10f; // Maximum fýrlatma gücü
    public float minRotationSpeed = 10f;
    public float maxRotationSpeed = 50f;
    int launchCount;
    void Start()
    {
        StartCoroutine(LaunchPooling());
    }
    void Update()
    {
    }
    IEnumerator LaunchPooling()
    {
        while (true)
        {
            PosYRectToTransform();
            launchCount = launchCount % fruits.Count;
            LaunchObject(fruits[launchCount]);
            launchCount++;
            float delay = Random.Range(0.5f, 1.5f);
            yield return new WaitForSeconds(delay);
        }
        
    }
    public void PosYRectToTransform()
    {
        LeftVektor = Camera.main.ScreenToWorldPoint(left.anchoredPosition);
        targetVektor.x = Random.Range(-Mathf.Abs(LeftVektor.x) , Mathf.Abs(LeftVektor.x));
        targetVektor.y = LeftVektor.y;
        transform.position = targetVektor;
    }

    public void LaunchObject(GameObject GO)
    {
        if (GO != null && !GO.activeSelf)
        {
            //partýcle color
            int randomÝndex = Random.Range(0, fruitCreates.Count);
            GO.GetComponent<SpriteRenderer>().sprite = fruitCreates[randomÝndex].sprite;
            var m = GO.GetComponent<ParticleSystem>().main;
            var c1 = m.startColor;
            c1.colorMin = fruitCreates[randomÝndex].color1;
            c1.colorMax = fruitCreates[randomÝndex].color2;
            m.startColor = c1;
            
            GO.SetActive(true);
            GO.GetComponent<Fruit>().ParticleStop();
            Rigidbody2D rb = GO.GetComponent<Rigidbody2D>();
            GO.transform.position = gameObject.transform.position;
            if (rb != null)
            {
                float angle;
                if (transform.position.x>0)
                {
                     angle = Random.Range(90f, 120f); // Rastgele açý
                }
                else
                {
                     angle = Random.Range(60f, 90f); // Rastgele açý
                }
                float force = Random.Range(minForce, maxForce); // Rastgele güç
                //if(angle>80&&angle<100)
                //{
                //    force=Random.Range(minForce-minForce/3, maxForce-maxForce/3);
                //}

                // Açý ve güç ile objeyi fýrlat
                Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

                rb.AddForce(direction * force, ForceMode2D.Impulse);
                float rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
                int randomDirection = (Random.Range(0, 2) == 0) ? 1 : -1;
                rb.angularVelocity = rotationSpeed * randomDirection;
            }
        }
    }
}
