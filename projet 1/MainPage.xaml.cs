using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace projet_1;

public partial class MainPage : ContentPage
{

    // process

    // 1 - installer le Nuget Selenium
    //			* Aller dans Outils
    //			* Choisir Gestionnaire de package Nuget
    //			* Choisir gerer les package Nuget
    //			* Cliquer sur Parcourir
    //			* Saisir selenium
    //			* Choisir Selenium.WebDriver.ChromeDriver
    //          * Installer le navigateur Chrome
    //          * Installer ( si absent ) le driver chrome a l'emplacement  : sur c  dans  Drivers   dans   Web

    public MainPage()
    {
        InitializeComponent();
        this.LireUnFichierPourSelenium();
    }

    public void LancerNavigateur()
    {
        // Creer un objet chromedriver
        IWebDriver driver = new ChromeDriver(@"c:\Drivers\Web");
        // La methode lance le navigateur à l'adresse google.com
        driver.Navigate().GoToUrl("https://google.com");
        // la methode dort pendant 10 secondes
        Thread.Sleep(10000);
        // la methode quitte le navigateur
        driver.Quit();
    }

    public void CliquerSurUnBouton()
    {
        // Creer un objet chromedriver
        IWebDriver driver = new ChromeDriver(@"c:\Drivers\Web");
        // La methode lance le navigateur à l'adresse google.com
        driver.Navigate().GoToUrl("https://google.com");
        // la methode dort pendant 5 secondes
        Thread.Sleep(5000);
        // la methode trouve sur la page l'élément défini (ici le bouton Accepter
        var element = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[3]/span/div/div/div/div[3]/div[1]/button[2]/div"));
        // La methode simule un click sur le bouton
        element.Click();
        // Je positionne mon curseur dans la zone de saisie de google
        element = driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input"));
        // je saisis le texte que je desire rechercher
        element.SendKeys("asus");
        // je lance la recherche du terme saisi
        element.Submit();
        // la methode dort pendant 3 secondes
        Thread.Sleep(3000);
        // je desire aller sur la page 2
        element = driver.FindElement(By.LinkText("2"));
        // je clique sur le lien 2
        element.Click();
        // je veux faire defiler les pages de recherche GOOGLE
        // je cree une case memoire pour me souvenir du numero de la page

        // int compteur = 3 le compteur demarre à 3
        // compteur <= 10000 le compteur termine à 10000
        // compteur++ A chaque passage dans la boucle , il ajoute 1
        // nb correspond à la case memoire  de la page en cours
        int nb = 3;
        for (int compteur = 1; compteur <= 10000; compteur++)
        {
            // pour eviter les exceptions on utilise la commande try - catch
            try
            {

                //Je recherche un lien qui correspond à la case memoire nb
                var element2 = driver.FindElement(By.LinkText(nb.ToString()));
                // je clique
                element2.Click();
                // j'ajoute 1 à la case memoire
                nb++;
                // recuperer le texte
                element = driver.FindElement(By.Id("result-stats"));
                // Tester le contenu pour savoir s'il contient Auchan
                if (element.Text.Contains("Page 6"))
                {
                    break;
                }
                // je veux recuperer tous les elements qui contiennent le Tag h3
                var elements = driver.FindElements(By.TagName("h3"));
                // je veux recuperer le texte de chaque Tag h3
                // Etape  01 - créer une boucle
                foreach (var monElement in elements)
                {
                    // je mets le texte du h3 dans une case
                    string monTexte = monElement.Text;
                    // on recherche par un test le site "BACK TO SCHOOL 2022 - ASUS"
                    if (monTexte.Equals("BACK TO SCHOOL 2022 - ASUS"))
                    {
                        monElement.Click();
                        break;
                    }
                } // je m'endors 3 secondes
                Thread.Sleep(3000);
            }
            catch (Exception ex) { }
        }

    }

    public void LireUnFichierPourSelenium()
    {
        // Creer un objet chromedriver
        IWebDriver driver = new ChromeDriver(@"c:\Drivers\Web");
        // La methode lance le navigateur à l'adresse google.com
        driver.Navigate().GoToUrl("https://ldlc.com");
        driver.Manage().Window.FullScreen();
        // la methode dort pendant 5 secondes
        Thread.Sleep(5000);
        // On definit le chemin du fichier à lire
        string cheminDuFichier = @"C:\Users\ymevel\Documents\selenium.txt";
        // On lis l'ensemble des lignes du fichiers
        string[] lignes = File.ReadAllLines(cheminDuFichier);
        // On parcours le tableau contenant toutes les lignes
        foreach (string ligne in lignes)
        {
            // on découpe chaque mot de la ligne séparé par un ;
            string[] mots = ligne.Split(';');
            // dans le tableau mots, le 1er mot est le mot 0
            string mot0 = mots[0];
            string mot1 = mots[1];
            driver.Manage().Window.FullScreen();
            // la methode trouve sur la page l'élément défini (ici le bouton Accepter
            var element = driver.FindElement(By.XPath("/html/body/header/div[2]/div/div/form/div/div[2]/div[1]/input"));
            // Je nettoie la zone de saisie
            element.Clear();
            // la methode dort pendant 5 secondes
            Thread.Sleep(5000);
            // je saisis le texte que je desire rechercher
            element.SendKeys(mot0);
            // La methode simule un click sur le bouton
            element.Submit();
            driver.Manage().Window.FullScreen();
            // la methode dort pendant 5 secondes
            Thread.Sleep(5000);

        }
    }
}