using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    private Ship ship;

    //Panels
    public GameObject shipPanel;
    public GameObject planetPanel;
    public GameObject planetPanel2;
    public GameObject loadPanel;
    public GameObject victoryPanel;

    public GameObject[] planetHighlight;

    public GameObject[] colonizeHighlight;

    //Text
    public Text[] planetNamesText;
    public Text gravityText;
    public Text temperatureText;
    public Text plantsText;
    public Text animalsText;
    public Text atmosphereText;
    public Text waterText;
    public Text habitableText;
    public Text victoryText;

   
    public TMP_InputField planetgivenname;

    //Public int orbit
    public int planetNumber = 3;
    private int[] planetTypeTable = { 5, 50 };
    private int[] liveableGasPlanetTable = { 1, 2 };
    private int[] atmosphereTable = { 5, 15, 30, 55, 100 };
    private int[] waterTable = { 1, 2 };
    private int[] gravityTable = { 5, 15, 25, 35, 45, 110 };
    private int[] ringTable = { 70, 80, 90, 100 };
    private int[] starSizeTable = { 10, 20, 30 };
    private int planetTypeRandom;
    private int atmosphereRandom;
    private int liveableGasPlanetRandom;
    private int waterRandom;
    private int gravityRandom;
    private int plantRandom;
    private int animalRandom;
    private int ringRandom;
    private int starRandom;

    //Variables
    private bool solidPlanet;
    private bool breathable = false;
    private int gravity;
    private int temperature;
    private bool plants = false;
    private bool animals;
    private int atmosphere;
    private bool water;
    private int rings = 0;
    private bool habitable;
    public bool colonize;
    public int score;


    //Errors
    private int atmosphereError;
    private int temperatureError;
    private int waterError;
    private int gravityError;
    private int plantsError;
    private int animalsError;

    //Planet visualizer
    private string planetName = "EXO ";
    private int planetNunmber;
    private string[] gravityDisplay =
    {
        "GRAVITY: 1G : Earthlike.",
        "GRAVITY: < 0.3G : Very Light.",
        "GRAVITY: 0.3G - 0.9G : Light.",
        "GRAVITY: 1G - 1.5G : Heavy.",
        "GRAVITY: 1.5G - 2.8G : Very Heavy.",
        "GRAVITY: > 2.8G : Unliveable."
    };
    private string temperatureDisplay = "Temperature: ";
    private string[] atmosphereDisplay =
    {
        "ATMOSPHERE: Breathable.",
        "ATMOSPHERE: Breathing Mask.",
        "ATMOSPHERE: Pressurized Suits.",
        "ATMOSPHERE: Barely Liveable.",
        "ATMOSPHERE: No Atmosphere."
    };
    private const string habitablePlanetText = "This planet can sustain life";
    private const string inhabitablePlanetText = "This planet cannot sustain life";
    private const string floraText = "There is flora in this planet.";
    private const string noFloraText = "There is no flora";
    private const string faunaText = "There are animals";
    private const string noFaunaText = "There are no animals";
    private const string waterDisplayText = "There is water in this planet.";
    private const string noWaterDisplayText = "There is no water in this planet.";
    private const string errorDisplayText = "There has been a error.";

    private const string colonizeText = "You have colonized ";
    private const string goodEndingText = "You did it! You found the best possible planet to habit and humanity has thrived thansk to your efforts. At least for now...";
    private const string okayEndingText = "You found a good enough planet, humanity will use it as a base but it will most likely have to move in some centuries hopefully they have enough time to build another one of you...";
    private const string badEndingText = "You doomed humanity! The planet you found wasn't suitable and humanity has gone extinct this is the end, perhaps they shouldn't have trusted in a machine afterall...";

    public PlanetData[] planets;

    public bool planet1Generated = false;
    public bool planet2Generated = false;
    public bool planet3Generated = false;
    private bool starGeneratred = false;

    void Start()
    {
        

        planets = new PlanetData[planetNumber];

        //planetHighlight = new GameObject[planetNumber];
        //colonizeHighlight = new GameObject[planetNumber];

        ship = GameObject.Find("SpaceShip").GetComponent<Ship>();

        //for (int i = 1; i < planetHighlight.Length; i++)
        //{
        //    planetHighlight[i] = GameObject.Find("PlanetMouseOver" + i.ToString());
        //}

        //for (int i = 1; i < colonizeHighlight.Length; i++)
        //{
        //    planetHighlight[i] = GameObject.Find("ColonizeMouseOver" + i.ToString());
        //}
    }

    private void Update()
    {
        

       

     
    }
    public void OrbitPlanet(int orbit)
    {
        planetTypeRandom = Random.Range(0, planetTypeTable[planetTypeTable.Length - 1]);
        liveableGasPlanetRandom = Random.Range(0, liveableGasPlanetTable[liveableGasPlanetTable.Length - 1]);
        atmosphereRandom = Random.Range(0, atmosphereTable[atmosphereTable.Length - 1]);
        waterRandom = Random.Range(0, waterTable[waterTable.Length - 1]);
        gravityRandom = Random.Range(0, gravityTable[gravityTable.Length - 1]);
        plantRandom = Random.Range(0, 2);
        animalRandom = Random.Range(0, 2);
        ringRandom = Random.Range(0, ringTable[ringTable.Length - 1]);

        if (starGeneratred == false)
        {
            starRandom = Random.Range(0, starSizeTable[starSizeTable.Length - 1]);
            starGeneratred = true;
        }

        //Planet Number
        planetNumber = Random.Range(10000, 99999);

        //Ring
        if (ringRandom < ringTable[0])
        {
            rings = 0;
        }
        else if (ringRandom < ringTable[1])
        {
            rings = 1;
        }
        else if (ringRandom < ringTable[2])
        {
            rings = 2;
        }
        else if (ringRandom < ringTable[3])
        {
            rings = 3;
        }

        //Atmosphere
        if (atmosphereRandom < atmosphereTable[0])
        {
            atmosphere = 0;
            breathable = true;
        }
        else if (atmosphereRandom < atmosphereTable[1])
        {
            atmosphere = 1;
            breathable = true;
        }
        else if (atmosphereRandom < atmosphereTable[2])
        {
            atmosphere = 2;
            breathable = true;
        }
        else if (atmosphereRandom < atmosphereTable[3])
        {
            atmosphere = 3;
        }
        else
        {
            atmosphere = 4;
        }

        //Temperature
        if (orbit == 1)
        {
            temperature = Random.Range(-150, -50);
        }
        else if (orbit == 2 && atmosphere <= 4)
        {
            temperature = Random.Range(-25, 100);
        }
        else if (orbit == 2 && atmosphere > 4)
        {
            temperature = Random.Range(-150, -50);
        }
        else if (orbit == 3)
        {
            temperature = Random.Range(50, 150);
        }

        //Water
        if (atmosphere != 4 && waterRandom < waterTable[0])
        {
            water = true;
        }
        else
        {
            water = false;
        }

        //Gravity
        if (gravityRandom < gravityTable[0])
        {
            //Earthlike Gravity
            gravity = 0;
        }
        else if (gravityRandom < gravityTable[1])
        {
            //Very Light Gravity
            gravity = 1;
        }
        else if (gravityRandom < gravityTable[2])
        {
            //Light Gravity
            gravity = 2;
        }
        else if (gravityRandom < gravityTable[3])
        {
            //Heavy Gravity
            gravity = 3;
        }
        else if (gravityRandom < gravityTable[4])
        {
            //Very Heavy Gravity
            gravity = 4;
        }
        else
        {
            //Unliveable
            gravity = 5;
        }

        if (orbit == 1 && starRandom < starSizeTable[0] && solidPlanet == true)
        {
            habitable = true;
        }

        if (orbit == 2 && starRandom > starSizeTable[0] && starRandom < starSizeTable[1] && solidPlanet == true)
        {
            habitable = true;
        }

        if (orbit == 3 && starRandom > starSizeTable[1] && starRandom < starSizeTable[2] && solidPlanet == true)
        {
            habitable = true;
        }

        if (solidPlanet == false && liveableGasPlanetRandom < liveableGasPlanetTable[0])
        {
            habitable = true;
        }

        //Life
        if (solidPlanet == true && breathable == true && temperature > -10 && temperature < 70 && gravity > 5 && plantRandom < 1 && habitable == true)
        {
            plants = true;
        }
        else
        {
            plants = false;
        }

        if (plants = true && animalRandom < 1 && gravity > 4)
        {
            animals = true;
        }
        else
        {
            animals = false;
        }

        //PlanetType
        if (planetTypeRandom < planetTypeTable[0])
        {
            solidPlanet = false;

            gravity = 4;
            atmosphere = 4;
            plants = false;
            animals = false;
            water = false;
        }
        else
        {
            solidPlanet = true;
        }

        if (orbit == 1 && planet1Generated == false) //gravity | temperature | plants | animals | atmosphere | water | rings | habitable
        {
            planets[0] = new PlanetData(planetName + planetNumber.ToString(), solidPlanet, gravity, temperature, plants, animals, atmosphere, water, rings, habitable);

            planet1Generated = true;
        }
        else if (orbit == 2 && planet2Generated == false)
        {
            planets[1] = new PlanetData(planetName + planetNumber.ToString(), solidPlanet, gravity, temperature, plants, animals, atmosphere, water, rings, habitable);

            planet2Generated = true;
        }
        else if (orbit == 3 && planet3Generated == false)
        {
            planets[2] = new PlanetData(planetName + planetNumber.ToString(), solidPlanet, gravity, temperature, plants, animals, atmosphere, water, rings, habitable);

            planet3Generated = true;
        }

        planetNamesText[orbit - 1].text = planetName + planetNumber.ToString();
    }

    public void ReturnButton(bool toShip)
    {
        if (toShip == true)
        {
            shipPanel.SetActive(true);
            planetPanel.SetActive(false);

            planet1Generated = false;
            planet2Generated = false;
            planet3Generated = false;
            starGeneratred = false;
            colonize = false;
            ship.noScoutText.SetActive(false);
        }
        else if (toShip == false)
        {
            planetPanel.SetActive(true);
            planetPanel2.SetActive(false);
        }
    }

    public void DisplayPlanet(int planetNumber)
    {
        if (colonize == false)
        {
            planetPanel.SetActive(false);
            loadPanel.SetActive(true);            

            if (ship.gravitySensor <= 100)
            {
                gravityText.text = gravityDisplay[planets[planetNumber].gravity];
            }
            else if (ship.gravitySensor < 75)
            {
                gravityError = Random.Range(0, 1);
                if (gravityError == 0)
                    gravityText.text = gravityDisplay[planets[planetNumber].gravity];
                else
                    gravityText.text = errorDisplayText;
            }
            else if (ship.gravitySensor < 50)
            {
                gravityError = Random.Range(0, 4);
                if (gravityError == 0)
                    gravityText.text = gravityDisplay[planets[planetNumber].gravity];
                else
                    gravityText.text = errorDisplayText;
            }
            else if (ship.gravitySensor < 25)
            {
                gravityError = Random.Range(0, 6);
                if (gravityError == 0)
                    gravityText.text = gravityDisplay[planets[planetNumber].gravity];
                else
                    gravityText.text = errorDisplayText;
            }

            if (ship.temperatureSensor <= 100)
            {
                temperatureText.text = temperatureDisplay + planets[planetNumber].temperature.ToString() + "ºC.";
            }
            else if (ship.temperatureSensor < 75)
            {
                temperatureError = Random.Range(0, 1);
                if (temperatureError == 0)
                    temperatureText.text = temperatureDisplay + planets[planetNumber].temperature.ToString() + "ºC.";
                else
                    temperatureText.text = errorDisplayText;
            }
            else if (ship.temperatureSensor < 50)
            {
                temperatureError = Random.Range(0, 4);
                if (temperatureError == 0)
                    temperatureText.text = temperatureDisplay + planets[planetNumber].temperature.ToString() + "ºC.";
                else
                    temperatureText.text = errorDisplayText;
            }
            else if (ship.temperatureSensor < 25)
            {
                temperatureError = Random.Range(0, 6);
                if (temperatureError == 0)
                    temperatureText.text = temperatureDisplay + planets[planetNumber].temperature.ToString() + "ºC.";
                else
                    temperatureText.text = errorDisplayText;
            }

            if (ship.atmosphereSensor <= 100)
            {
                atmosphereText.text = atmosphereDisplay[planets[planetNumber].atmosphere];
            }
            else if (ship.atmosphereSensor < 75)
            {
                atmosphereError = Random.Range(0, 1);
                if (atmosphereError == 0)
                    atmosphereText.text = atmosphereDisplay[planets[planetNumber].atmosphere];
                else
                    atmosphereText.text = errorDisplayText;
            }
            else if (ship.atmosphereSensor < 50)
            {
                atmosphereError = Random.Range(0, 4);
                if (atmosphereError == 0)
                    atmosphereText.text = atmosphereDisplay[planets[planetNumber].atmosphere];
                else
                    atmosphereText.text = errorDisplayText;
            }
            else if (ship.atmosphereSensor < 25)
            {
                atmosphereError = Random.Range(0, 6);
                if (atmosphereError == 0)
                    atmosphereText.text = atmosphereDisplay[planets[planetNumber].atmosphere];
                else
                    atmosphereText.text = errorDisplayText;
            }

            if (ship.waterSensor <= 100)
            {
                waterText.text = (planets[planetNumber].water == false ? noWaterDisplayText : waterDisplayText);
            }
            else if (ship.waterSensor < 75)
            {
                waterError = Random.Range(0, 1);
                if (waterError == 0)
                    waterText.text = (planets[planetNumber].water == false ? noWaterDisplayText : waterDisplayText);
                else
                    waterText.text = errorDisplayText;
            }
            else if (ship.waterSensor < 50)
            {
                waterError = Random.Range(0, 4);
                if (waterError == 0)
                    waterText.text = (planets[planetNumber].water == false ? noWaterDisplayText : waterDisplayText);
                else
                    waterText.text = errorDisplayText;
            }
            else if (ship.waterSensor < 25)
            {
                waterError = Random.Range(0, 6);
                if (waterError == 0)
                    waterText.text = (planets[planetNumber].water == false ? noWaterDisplayText : waterDisplayText);
                else
                    waterText.text = errorDisplayText;
            }

            if (ship.resourcesSensor <= 100)
            {
                plantsText.text = (planets[planetNumber].plants == false ? noFloraText : floraText);
            }
            else if (ship.resourcesSensor < 75)
            {
                plantsError = Random.Range(0, 1);
                if (plantsError == 0)
                    plantsText.text = (planets[planetNumber].plants == false ? noFloraText : floraText);
                else
                    plantsText.text = errorDisplayText;
            }
            else if (ship.resourcesSensor < 50)
            {
                plantsError = Random.Range(0, 4);
                if (plantsError == 0)
                    plantsText.text = (planets[planetNumber].plants == false ? noFloraText : floraText);
                else
                    plantsText.text = errorDisplayText;
            }
            else if (ship.resourcesSensor < 25)
            {
                plantsError = Random.Range(0, 6);
                if (plantsError == 0)
                    plantsText.text = (planets[planetNumber].plants == false ? noFloraText : floraText);
                else
                    plantsText.text = errorDisplayText;
            }

            if (ship.lifeSensor <= 100)
            {
                animalsText.text = (planets[planetNumber].animals == false ? noFaunaText : faunaText);
            }
            else if (ship.lifeSensor < 75)
            {
                animalsError = Random.Range(0, 1);
                if (animalsError == 0)
                    animalsText.text = (planets[planetNumber].animals == false ? noFaunaText : faunaText);
                else
                    animalsText.text = errorDisplayText;
            }
            else if (ship.lifeSensor < 50)
            {
                animalsError = Random.Range(0, 4);
                if (animalsError == 0)
                    animalsText.text = (planets[planetNumber].animals == false ? noFaunaText : faunaText);
                else
                    animalsText.text = errorDisplayText;
            }
            else if (ship.lifeSensor < 25)
            {
                animalsError = Random.Range(0, 6);
                if (animalsError == 0)
                    animalsText.text = (planets[planetNumber].animals == false ? noFaunaText : faunaText);
                else
                    animalsText.text = errorDisplayText;
            }

            habitableText.text = (planets[planetNumber].habitable == true ? habitablePlanetText : inhabitablePlanetText);
        }
        else if (colonize == true)
        {




            planetPanel.SetActive(false);

            if (planets[planetNumber].gravity == 0)
                score += 100;
            else if (planets[planetNumber].gravity == 1)
                score += 80;
            else if (planets[planetNumber].gravity == 2)
                score += 60;
            else if (planets[planetNumber].gravity == 3)
                score += 40;
            else if (planets[planetNumber].gravity == 4)
                score += 10;


            if (planets[planetNumber].atmosphere == 0)
                score += 100;
            else if (planets[planetNumber].atmosphere == 1)
                score += 60;
            else if (planets[planetNumber].atmosphere == 2)
                score += 40;
            else if (planets[planetNumber].atmosphere == 3)
                score += 10;


            if (planets[planetNumber].temperature < 0 && planets[planetNumber].temperature > 40)
                score += 100;
            else if (planets[planetNumber].temperature < 40 && planets[planetNumber].temperature > 100)
                score += 20;
            else if (planets[planetNumber].temperature < -40 && planets[planetNumber].temperature > -100)
                score += 20;


            if (planets[planetNumber].water == true)
                score += 100;


            if (planets[planetNumber].plants == true)
                score += 100;


            if (planets[planetNumber].animals == true)
                score += 100;


            if (score > 400)
                victoryText.text = colonizeText + planetgivenname.text + goodEndingText;
            else if (score > 100)
                victoryText.text = colonizeText + planetgivenname.text + okayEndingText;
            else
                victoryText.text = colonizeText + planetgivenname.text   + badEndingText;

            victoryPanel.SetActive(true);
        }
    }

    public void Loaded()
    {
        loadPanel.SetActive(false);
        planetPanel2.SetActive(true);
    }

    public void Colonize()
    {
        colonize = true;
    }

    public void HighlightIconActivate(int planetOrbit)
    {
        if (colonize == true)
        {
            colonizeHighlight[planetOrbit].SetActive(true);
            planetHighlight[planetOrbit].SetActive(false);
        }
        else
        {
            colonizeHighlight[planetOrbit].SetActive(false);
            planetHighlight[planetOrbit].SetActive(true);
        }
    }

    public void HighlightIconDeactivate(int planetOrbit)
    {
        colonizeHighlight[planetOrbit].SetActive(false);
        planetHighlight[planetOrbit].SetActive(false);
    }
}