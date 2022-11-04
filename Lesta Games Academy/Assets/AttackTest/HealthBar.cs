using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    Image Bar;
    public Text Name;
    public Text Health;

    public float maxHealth;
    float hp;

    public float attackSpeedEnemy;
    public int minDamageEnemy;
    public int maxDamageEnemy;

    static int numberOfAttempts = 0;

    private void Start()
    {
        Bar = GetComponent<Image>();
        hp = maxHealth;
        
        if(numberOfAttempts < 100)
            InvokeRepeating("Attack", 1.0f, attackSpeedEnemy);
    }

    private void Update()
    {
        Bar.fillAmount = hp / maxHealth;
        Health.text = hp.ToString();
    }

    void Attack()
    {
        hp -= Random.Range(minDamageEnemy, maxDamageEnemy);

        if (hp <= 0)
        {
            var ans = Name.text + " loser";
            Debug.Log(ans);

            numberOfAttempts++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}