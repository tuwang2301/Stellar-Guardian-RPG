using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject[] planets;

    private GameObject selectedPlanet;

    [SerializeField] private Text coinText;
    [SerializeField] private Text currentHealthText;
    [SerializeField] private Text staminaTimeText;

    [SerializeField] private Button button;
    [SerializeField] private GameObject Shop;

    [SerializeField]
    private Text value;


    private void Start()
    {

        if (button != null)
        {
            button.onClick.AddListener(LeaveShop);
        }
        SelectPlanet(planets[0]);
    }

    void Update()
    {
        int coins = EconomyManager.Instance.currentGold != null ? EconomyManager.Instance.currentGold : 0;
        int currentHealth = PlayerHealth.Instance.currentHealth != null ? PlayerHealth.Instance.currentHealth : 10;
        int staminaTime = Stamina.Instance.timeBetweenStaminaRefresh != null ? Stamina.Instance.timeBetweenStaminaRefresh : 3;
        coinText.text = coins.ToString();
        currentHealthText.text = (currentHealth * 10).ToString() + "%";
        staminaTimeText.text = staminaTime.ToString() + ".0s";
    }

    public void OnClick(int index)
    {
        SelectPlanet(planets[index]);
    }

    public void Buy()
    {
        int coins = EconomyManager.Instance.currentGold;
        Debug.Log("aaaaa: " + coins);
        int index = GetIndex(selectedPlanet);
        int balance = coins - int.Parse(value.text);


        if (coins >= int.Parse(value.text))
        {
            // withdraw the game object value from total coins and update text value
            EconomyManager.Instance.currentGold = balance;
            if (index == 2)
            {
                PlayerHealth.Instance.currentHealth += 5;
                if (PlayerHealth.Instance.currentHealth > 10)
                {
                    PlayerHealth.Instance.currentHealth = 10;
                }
            }

            if (index == 3)
            {
                PlayerHealth.Instance.currentHealth = 10;
            }

            if (index == 4)
            {
                Stamina.Instance.timeBetweenStaminaRefresh -= 2;
            }

            if (index != 2 && index != 3)
            {
                selectedPlanet.SetActive(false);
            }

        }

    }

    private void SelectPlanet(GameObject obj)
    {
        int index = GetIndex(obj);

        if (selectedPlanet)
        {
            GetChildGameObject(selectedPlanet, 1).SetActive(false);
            selectedPlanet = obj;
        }
        else
        {
            selectedPlanet = obj;
        }
        GetChildGameObject(obj, 1).SetActive(true);

        //change text value with the planet game object value
        value.text = GetChildGameObject(obj, 0).GetComponent<Text>().text;

    }


    // return a child game object from a game object
    private GameObject GetChildGameObject(GameObject obj, int child)
    {
        return obj.transform.GetChild(child).gameObject;
    }

    private void OnScreenLeave()
    {
        int index = GetIndex(selectedPlanet);
        PlayerPrefs.SetInt("selected", index);
        PlayerPrefs.SetInt("status " + index, 1);
    }

    // find the game object index and save
    private int GetIndex(GameObject obj)
    {
        int index = 0;

        while (obj != planets[index])
        {
            index++;
        }

        return index;
    }

    public void LeaveShop()
    {
        Shop.SetActive(false);
    }
}