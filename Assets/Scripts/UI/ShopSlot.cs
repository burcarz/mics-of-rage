using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class ShopSlot : MonoBehaviour
{

    public Potion potion;
    public Charm charm;
    public Ability ability;

    public Image itemIcon;

    public TMP_Text displayName;
    public TMP_Text description;
    public TMP_Text cost;
    public TMP_Text flavor;
    
    public ShopDisplay display;
    public Player player;
    public Inventory playerInventory;

    public bool isOccupied = false;
    public bool purchased = false;

    void Start()
    {
        isOccupied = false;
    }

    public void BuyItem()
    {
        if (potion)
        {
            Debug.Log("Item is a potion, " + potion);
            BuyPotion();
        }

        if (ability)
        {
            Debug.Log("Item is an ability, " + ability);
            BuyAbility();
        }

        if (charm)
        {
            Debug.Log("Item is a charm, " + charm);
            BuyCharm();
        }
    }

    public void AddPotion(Potion newPotion)
    {
        potion = newPotion;

        if (potion.icon)
        {
            itemIcon.sprite = potion.icon;
            displayName.text = potion.displayName;
            description.text = potion.description;
            cost.text = potion.cost.ToString();
            flavor.text = potion.flavor;

        }

    }

    public void AddCharm(Charm newCharm)
    {
        charm = newCharm;

        if (charm.icon)
        {
            itemIcon.sprite = charm.icon;
            displayName.text = charm.displayName;
            description.text = charm.description;
            cost.text = charm.cost.ToString();
            flavor.text = charm.flavor;
        }
    }

    public void AddAbility(Ability newAbility)
    {
        ability = newAbility;

        if (ability.icon)
        {
            itemIcon.sprite = ability.icon;
            displayName.text = ability.displayName;
            description.text = ability.description;
            cost.text = ability.cost.ToString();
            flavor.text = ability.flavor;
        }
    }

    public void ClearSlot()
    {

        if (potion)
        {
            potion = null;
        }
        if (charm)
        {
            charm = null;
        }
        if (ability)
        {
            ability = null;
        }

        itemIcon.enabled = false;
    }

    public void BuyPotion()
    {
        // check price of desired shop item
        // if player has enough points then buy item and add to inventory
        Debug.Log(player.points);
        if (player.points >= potion.cost)
        {
            player.points -= potion.cost;
            GameStateManager.Instance.playerPoints = player.points;
            Debug.Log(player.points);

            playerInventory.addPotion(potion);
            display.RemoveShopPotion(potion);

            purchased = true;
            display.UpdateDisplay();
        }
        else
        {
            Debug.Log("You can't afford this!");
        }
    }

    public void BuyCharm()
    {
        Debug.Log(player.points);
        if (player.points >= charm.cost)
        {
            player.points -= charm.cost;
            GameStateManager.Instance.playerPoints = player.points;
            Debug.Log(player.points);

            playerInventory.addCharm(charm);
            display.RemoveShopCharm(charm);

            purchased = true;
            display.UpdateDisplay();
        }
        else
        {
            Debug.Log("You can't afford this!");
        }
    }

    public void BuyAbility()
    {
        Debug.Log(player.points);
        if (player.points >= ability.cost)
        {
            player.points -= ability.cost;
            GameStateManager.Instance.playerPoints = player.points;
            Debug.Log(player.points);

            playerInventory.addAbility(ability);
            display.RemoveShopAbility(ability);
            
            purchased = true;
            display.UpdateDisplay();
        }
        else
        {
            Debug.Log("You can't afford this!");
        }
    }
}
