﻿using AutomationFinalProject.PageObjects;
using NUnit.Framework;

namespace AutomationFinalProject
{
    public class Tests : Hooks
    {
        [Test]
        public void AddProductToCart()
        {
            HomePage myHomePage = new HomePage(Driver);
            SearchedProductsPage mySearchedProductsPage = new SearchedProductsPage(Driver);
            ProductOverviewPage myProductOverviewPage = new ProductOverviewPage(Driver);
            ShoppingCartPage myShoppingCartPage = new ShoppingCartPage(Driver);

            myHomePage.ClickOnProductCategory("Mobile", "Smartphone");
            mySearchedProductsPage.SortProductsByText("Rating clienti");
            mySearchedProductsPage.ClickOnSpecifiedProductByIndex(1);
            myProductOverviewPage.ClickOnAddToShoppingCartButton();
            Assert.IsTrue(myShoppingCartPage.EmptyShoppingCartButton.Displayed);
        }

        [Test]
        public void CreateWishlsitWithCartProducts()
        {
            HomePage myHomePage = new HomePage(Driver);
            SearchedProductsPage mySearchedProductsPage = new SearchedProductsPage(Driver);
            ProductOverviewPage myProductOverviewPage = new ProductOverviewPage(Driver);
            ShoppingCartPage myShoppingCartPage = new ShoppingCartPage(Driver);
            WishlistPage myWishlistPage = new WishlistPage(Driver);

            myHomePage.ClickOnProductCategory("Componente", "Placi video");
            mySearchedProductsPage.SortProductsByText("Rating clienti");
            mySearchedProductsPage.ClickOnSpecifiedProductByIndex(0);
            myProductOverviewPage.ClickOnAddToShoppingCartButton();
            
            myHomePage.ClickOnProductCategory("Componente", "Procesoare");
            mySearchedProductsPage.SortProductsByText("Numar vizualizari");
            mySearchedProductsPage.ClickOnSpecifiedProductByIndex(1);
            myProductOverviewPage.ClickOnAddToShoppingCartButton();

            myHomePage.ClickOnProductCategory("Componente", "Placi de baza");
            mySearchedProductsPage.SortProductsByText("Top vanzari");
            mySearchedProductsPage.ClickOnSpecifiedProductByIndex(0);
            myProductOverviewPage.ClickOnAddToShoppingCartButton();

            myShoppingCartPage.ClickOnWishListButton();

            myWishlistPage.CreateWishlist("Automation test", "This a wishlist create by automation testing", "Autoamtion", "C#", "automationc#@someemail.com");
            Assert.IsTrue(myWishlistPage.WishlistConfidentialityCheckBox.Displayed);
        }

        [Test]
        public void LoginWithInvalidData()
        {
            HomePage myHomePage = new HomePage(Driver);
            LoginRegisterPage myLoginRegisterPage = new LoginRegisterPage(Driver);

            myHomePage.GoToLoginPage();
            myLoginRegisterPage.LoginIntoApplication("automationtest@somemail.com", "gegegergaswe");
            Assert.IsTrue(myLoginRegisterPage.LoginInvalidError.Displayed);
        }

        [Test]
        public void RegisterWithoutClickingConfidentialityBox()
        {
            HomePage myHomePage = new HomePage(Driver);
            LoginRegisterPage myLoginRegisterPage = new LoginRegisterPage(Driver);

            myHomePage.GoToLoginPage();
            myLoginRegisterPage.RegisterIntoApplication("Test", "Test", "0711111111", "automation@someemail.com", "123456", "123456");
            Assert.IsTrue(myLoginRegisterPage.RegisterConfidentialityError.Displayed);
        }
    }
}