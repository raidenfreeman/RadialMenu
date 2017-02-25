using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenu : MonoBehaviour
{

    public List<RadialMenuItemBase> MenuItems;

    public RadialMenuItemBase NavigationItem;

    public float Radius;

    public int NumberOfDisplayedItemsPerPage;

    private const int numberOfNavigationItems = 1;
    private int itemsPerPagePlusNavigationItems { get { return NumberOfDisplayedItemsPerPage + numberOfNavigationItems; } }
    private int numberOfPages;
    private int totalItems;

    private int currentlyShownPage;

    public int pageToShow;

    // Use this for initialization
    void Awake()
    {
        if (MenuItems != null)
        {
            totalItems = MenuItems.Count;

            numberOfPages = 0;
            for (var remainingItems = totalItems; remainingItems > 0; numberOfPages++)
            {
                if (numberOfPages == 0 && remainingItems == NumberOfDisplayedItemsPerPage || remainingItems + numberOfNavigationItems < NumberOfDisplayedItemsPerPage)
                {
                    //every item fits inside the first page, or we have enough space to fit everything + navigation
                    remainingItems -= NumberOfDisplayedItemsPerPage;
                }
                else
                {
                    //we have more items than can fit in a page
                    remainingItems -= NumberOfDisplayedItemsPerPage - numberOfNavigationItems; //we can put only  x - y items in the page, x: number of items per page, y: number of navigation items
                }
            }
        }
        DisplayMenuPage(pageToShow);
    }

    private void HidePage(int page)
    {
        var b = GetPageItems(page);
        foreach (var item in GetPageItems(page))
        {
            item.gameObject.SetActive(false);
        }
    }

    private void DisplayMenuPage(int page)
    {
        currentlyShownPage = page;
        for (int i = 1; i <= numberOfPages; i++)
        {
            if (i != page)
            {
                HidePage(i);
            }
        }
        if (MenuItems != null)
        {
            var itemsToShow = GetPageItems(page);
            if (numberOfPages > 1)
            {
                itemsToShow.Add(NavigationItem);
            }
            var totalItemsToShow = itemsToShow.Count();
            var anglePerItem = 360f / totalItemsToShow;
            int i = 0;
            foreach (var item in itemsToShow)
            {
                item.transform.localPosition = this.transform.localPosition;
                item.transform.localRotation = this.transform.localRotation;
                item.transform.Rotate(new Vector3(0, 0, -anglePerItem * i));
                item.transform.GetChild(0).Translate(new Vector3(0, Radius, 0));
                item.transform.GetChild(0).Rotate(-this.transform.localRotation.eulerAngles + new Vector3(0, 0, anglePerItem * i));
                item.enabled = true;
                i++;
            }
        }
    }

    public void CycleToNextPage()
    {
        currentlyShownPage++;
        if (currentlyShownPage > numberOfPages)
        {
            currentlyShownPage = 1;
        }
        DisplayMenuPage(currentlyShownPage);
    }
    private List<RadialMenuItemBase> GetPageItems(int page)
    {
        return MenuItems.Skip(Mathf.Max((page - 1), 0) * (NumberOfDisplayedItemsPerPage - numberOfNavigationItems)).Take(NumberOfDisplayedItemsPerPage - numberOfNavigationItems).ToList();
    }
}
