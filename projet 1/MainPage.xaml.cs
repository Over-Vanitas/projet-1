using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace projet_1;

public partial class MainPage : ContentPage
{
	// process

	// 1 - installer le Nuget Selenium
	//		* Aller dans Outils
	//		* Choisir Gestionnaire de package Nuget
	//		* Choisir gérer les packages
	//		* Cliquer sur Parcourir
	//		* Saisir selenium
	//		* Choisir Selenium.Webdriver.ChromeDriver
	//		* Installer le navigateur Chrome
	//		* Installer ( si absent ) le driver Chrome à l'emplacement  : sur c dans Drivers dans Web

	public MainPage()
	{
		InitializeComponent();
		this.CliquerSurUnBouton();
	}

	public void LancerNavigateur()
	{
		// Créer un objet chromedriver
		IWebDriver driver = new ChromeDriver(@"c:\Drivers\Web");
		// La méthode lance le Navigateur à l'adresse Google.com
		driver.Navigate().GoToUrl("https://google.com");
		// La méthode dort pendant 10 secondes
		Thread.Sleep(10000);
		// La méthode quitte le navigateur
		driver.Quit();
	}

	public void CliquerSurUnBouton()
	{
		// Créer un objet chromedriver
		IWebDriver driver = new ChromeDriver(@"c:\Drivers\Web");
        // La méthode lance le Navigateur à l'adresse Google.com
        driver.Navigate().GoToUrl("https://google.com");
        // La méthode dort pendant 5 secondes
        Thread.Sleep(5000);
		// La méthode trouve sur la page l'élément défini (ici le bouton "Accepter")x
		var element = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[3]/span/div/div/div/div[3]/div[1]/button[2]/div"));
		// La méthode simule un click sur le bouton
		element.Click();
		// Je positionne mon curseur dans la zone de saisie de Google
		element = driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input"));
		// Je saisie le texte que je désire rechercher
		element.SendKeys("asus");
		// Je lance la recherche du terme saisi
		element.Submit();
		// La méthode dors pendants 3 secondes
		Thread.Sleep(3000);
		// Je veux récupérer tous les élements qui contiennent le tag h3
		var elements = driver.FindElements(By.TagName("h3"));
		// Je veux récupérer le texte de chaque tag h3
		// Etape 01 - créer une boucle
		foreach(var monElement in elements) 
		{
            // Je met le texte du h3 dans une case
            string monTexte = monElement.Text;
		}
		// Je désire aller sur la page 2
		element = driver.FindElement(By.LinkText("2"));
		element.Click();
    }
}