﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace AutomationFinalProject.PageObjects
{
    public partial class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _driverWait;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            _driverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
        }

        public void InputTextInSearchBar(string searchCriteria)
        {
            SearchBar.SendKeys(searchCriteria);
            SearchBar.SendKeys(Keys.Enter);
        }

        public void ClickOnProductSubCategory(string category, string subCategory)
        {
            Thread.Sleep(1000);
            Actions action = new Actions(_driver);
            action.MoveToElement(ProductCategoryButton(category)).Perform();
            ProductSubCategoryButton(category, subCategory).Click();
        }

        public void ClickOnProductCategory(string category)
        {
            Thread.Sleep(1000);
            ProductCategoryButton(category).Click();
        }

        public void GoToWishListPage()
        {
            WishListButton.Click();
        }


        public void GoToLoginPage()
        {
            MyAccountButton.Click();
        }
    }
}