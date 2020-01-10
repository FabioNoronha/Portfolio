using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    //Flight counter
    public int flyTimes = 0;
    public Ship ship;

    //Panels
    public GameObject shipPanel;
    public GameObject planetPanel;
    public GameObject nebulaEventPanel;
    public GameObject asteroidEventPanel;
    public GameObject asteroidFieldEventPanel;
    public GameObject ruinPanel;
    public GameObject ruinPanel2;
    public GameObject ruinPanel3;
    public Text relicObtained;
    public Text relicReplace;

    //Text
    public Text planetSensorText;
    public Text atmosphereSensorText;
    public Text temperatureSensorText;
    public Text waterSensorText;
    public Text resourcesSensorText;
    public Text lifeSensorText;
    public Text gravitySensorText;

    //Equipment Menus
    public Dictionary<string, Sprite> equipmentDictionary1 = new Dictionary<string, Sprite>();
    public Dictionary<string, Sprite> equipmentDictionary2 = new Dictionary<string, Sprite>();
    public Dictionary<string, string> displayDictionary = new Dictionary<string, string>();

    public Image equipmentDisplay1;
    public Image equipmentDisplay2;

    public Text replacementText1;
    public Text replacementText2;

    public Sprite[] equipmentsSprite1;
    public int equipmentIndex1;
    public Sprite[] equipmentsSprite2;
    public int equipmentIndex2;

    //Ship stats
    public int healthPoint = 20;
    public int planetSensor = 100;
    public int atmosphereSensor = 100;
    public int temperatureSensor = 100;
    public int waterSensor = 100;
    public int resourcesSensor = 100;
    public int lifeSensor = 100;
    public int gravitySensor = 100;
    public int dataBase = 100;
    public int people = 50000;
    public int fuel = 20;
    public int sensorBay = 10;    

    //Equipement
    public string equip1;
    public string equip2;

    public bool equipment1 = false;
    public bool equipment2 = false;

    private string replace;
    private int inventory;

    public bool scoutRadar;
    public bool harvestEquipment; //Done
    public bool recyclingCenter; //Done
    public bool probeBay;
    public bool healingDroneBay;
    public bool lifeSupportBooster;

    //Event chances
    private int[] eventTable = { 5, 15, 30, 55, 100, 120 };
    private int eventRandom;

    private int[] nebulaTable = { 10, 20 };
    private int nebulaRandom;

    private int[] asteroidTable = { 10, 20, 30, 40, 50, 60, 70 };
    private int asteroidRandom;

    private int[] asteroidTable2 = { 10, 20, 30 };
    private int asteroidRandom2;

    private bool asteroidFieldHarvest;
    private int[] asteroidFieldTable = { 10, 20 };
    private int asteroidFieldRandom;

    private int[] ruinsItemTable = { 10, 20, 30, 40, 50, 60 };
    public int ruinsItemRandom;

    void Start()
    {
        //Equipment sprite list: scoutRadar = 1 | harvaster = 2 | recycler = 3 | probeBay = 4 | healingDrone = 5 | lifeSupportBooster = 6
        equipmentDictionary1.Add("empty", equipmentsSprite1[0]);
        equipmentDictionary1.Add("scoutRadar", equipmentsSprite1[1]);
        equipmentDictionary1.Add("harvaster", equipmentsSprite1[2]);
        equipmentDictionary1.Add("recycler", equipmentsSprite1[3]);
        equipmentDictionary1.Add("probeBay", equipmentsSprite1[4]);
        equipmentDictionary1.Add("healingDrone", equipmentsSprite1[5]);
        equipmentDictionary1.Add("lifeSupportBooster", equipmentsSprite1[6]);

        equipmentDictionary2.Add("empty", equipmentsSprite1[0]);
        equipmentDictionary2.Add("scoutRadar", equipmentsSprite1[1]);
        equipmentDictionary2.Add("harvaster", equipmentsSprite1[2]);
        equipmentDictionary2.Add("recycler", equipmentsSprite1[3]);
        equipmentDictionary2.Add("probeBay", equipmentsSprite1[4]);
        equipmentDictionary2.Add("healingDrone", equipmentsSprite1[5]);
        equipmentDictionary2.Add("lifeSupportBooster", equipmentsSprite1[6]);

        displayDictionary.Add("empty", "Empty");
        displayDictionary.Add("scoutRadar", "Scout Radar");
        displayDictionary.Add("harvaster", "Harvaster");
        displayDictionary.Add("recycler", "Recycler");
        displayDictionary.Add("probeBay", "Probe Bay");
        displayDictionary.Add("healingDrone", "Healing Drone Bay");
        displayDictionary.Add("lifeSupportBooster", "Life Support Booster");        
    }

    public void Fly()
    {
        //eventTotal = eventTotal[5];

        eventRandom = Random.Range(0, eventTable[eventTable.Length - 1]);

        flyTimes++;
        fuel--;
        
        if (eventRandom < eventTable[0])
        {
            //Super Nova
            Debug.Log("Super Nova");
        }
        else if (eventRandom < eventTable[1])
        {
            //Nebula
            Debug.Log("Nebula");
            shipPanel.SetActive(false);
            nebulaEventPanel.SetActive(true);
        }
        else if (eventRandom < eventTable[2])
        {
            //Asteroid Impact
            Debug.Log("Asteroid Impact");
            shipPanel.SetActive(false);
            asteroidEventPanel.SetActive(true);
        }
        else if (eventRandom < eventTable[3])
        {
            // Asteroid Field Event
            Debug.Log("Asteroid Field");
            shipPanel.SetActive(false);
            asteroidFieldEventPanel.SetActive(true);
        }
        else if (eventRandom < eventTable[4])
        {
            //Ruins
            Debug.Log("Ruins");
            Ruins(0);
            shipPanel.SetActive(false);
            ruinPanel.SetActive(true);
        }
        else if (eventRandom < eventTable[5])
        {
            //Nothing Happens
            Debug.Log("Nothing");
            shipPanel.SetActive(false);
            planetPanel.SetActive(true);
        }
    }

    public void Return()
    {
        shipPanel.SetActive(true);
        planetPanel.SetActive(false);
        nebulaEventPanel.SetActive(false);
        asteroidEventPanel.SetActive(false);
        asteroidFieldEventPanel.SetActive(false);
        ruinPanel.SetActive(false);
        ruinPanel2.SetActive(false);
        ruinPanel3.SetActive(false);
    }

    public void AsteroidImpact(int spot) // 1 = front, 2 = side, 3 = back, 4 = dodge atempt
    {
        asteroidRandom2 = Random.Range(0, asteroidTable2[asteroidTable2.Length - 1]);
        Debug.Log(asteroidRandom2);

        if (asteroidRandom2 < asteroidTable2[0])
        {
            switch (spot)
            {
                case 1:
                    planetSensor = planetSensor - 10;
                    break;
                case 2:
                    atmosphereSensor = atmosphereSensor - 10;
                    break;
                case 3:
                    resourcesSensor = resourcesSensor - 10;
                    break;
                case 4:
                    AsteroidImpactdodge();
                    break;
            }
        }
        else if (asteroidRandom2 < asteroidTable2[1])
        {
            switch (spot)
            {
                case 1:
                    temperatureSensor = temperatureSensor - 10;
                    break;
                case 2:
                    lifeSensor = lifeSensor - 10;
                    break;
                case 3:
                    waterSensor = waterSensor - 10;
                    break;
                case 4:
                    AsteroidImpactdodge();
                    break;
            }
        }
        else if (asteroidRandom2 < asteroidTable2[2])
        {
            switch (spot)
            {
                case 1:
                    gravitySensor = gravitySensor - 10;
                    break;
                case 2:
                    dataBase = dataBase - 10;
                    break;
                case 3:
                    people = people - Random.Range(0, flyTimes * 10);
                    break;
                case 4:
                    AsteroidImpactdodge();
                    break;
            }
        }
        shipPanel.SetActive(true);
        asteroidEventPanel.SetActive(false);
    }

    void AsteroidImpactdodge()
    {
        //asteroidRandom = Random.Range(0, 70);
        asteroidRandom = Random.Range(0, asteroidTable[asteroidTable.Length - 1]);

        if (asteroidRandom < asteroidTable[0])
        {
            planetSensor = planetSensor - 10;
            healthPoint--;
        }
        else if (asteroidRandom < asteroidTable[1])
        {
            atmosphereSensor = atmosphereSensor - 10;
            healthPoint--;
        }
        else if (asteroidRandom < asteroidTable[2])
        {
            temperatureSensor = temperatureSensor - 10;
            healthPoint--;
        }
        else if (asteroidRandom < asteroidTable[3])
        {
            waterSensor = waterSensor - 10;
            healthPoint--;
        }
        else if (asteroidRandom < asteroidTable[4])
        {
            resourcesSensor = resourcesSensor - 10;
            healthPoint--;
        }
        else if (asteroidRandom < asteroidTable[5])
        {
            lifeSensor = lifeSensor - 10;
            healthPoint--;
        }
        else if (asteroidRandom < asteroidTable[6])
        {
            gravitySensor = gravitySensor - 10;
            healthPoint--;
        }
        else
        {
            //nothing dodge succesful
        }
    }

    public void NebulaEvent(bool harvest)
    {
        if (harvest == true)
        {
            nebulaRandom = Random.Range(0, nebulaTable[nebulaTable.Length]);
            if (nebulaRandom < nebulaTable[0])
            {
                healthPoint--;
            }
            else
            {
                if (harvestEquipment == true)
                {
                    fuel = fuel + 2;
                }
                else
                {
                    fuel++;
                }
            }
        }
        shipPanel.SetActive(true);
        nebulaEventPanel.SetActive(false);
    }

    public void AsteroidFieldHarvast()
    {
        asteroidFieldRandom = Random.Range(0, asteroidFieldTable[asteroidFieldTable.Length - 1]);
        if (asteroidFieldRandom < asteroidFieldTable[0])
        {
            healthPoint--;
        }
        else
        {
            if (recyclingCenter == true)
            {
                fuel++;
                fuel++;
            }
            else
            {
                fuel++;
            }
        }
        Return();
    }

    public void Ruins(int ok)
    {
        if (ok == 0)
        {
            ruinsItemRandom = Random.Range(0, ruinsItemTable[ruinsItemTable.Length - 1]);

            if (ruinsItemRandom < ruinsItemTable[0])
            {
                if (equipment1 == false)
                {
                    scoutRadar = true;
                    equipment1 = true;
                    relicObtained.text = ("You obtained the Scout Radar");
                    equip1 = "scoutRadar";
                }
                else if (equipment2 == false)
                {
                    scoutRadar = true;
                    equipment2 = true;
                    relicObtained.text = ("You obtained the Scout Radar");
                    equip2 = "scoutRadar";
                }
                else
                {
                    relicObtained.text = ("You obtained the Scout Radar");
                    relicReplace.text = "You obtained the Scout Radar";
                    replace = "scoutRadar";
                }
            }
            else if (ruinsItemRandom < ruinsItemTable[1])
            {
                if (equipment1 == false)
                {
                    harvestEquipment = true;
                    equipment1 = true;
                    relicObtained.text = ("You obtained the Harvaster");
                    equip1 = "harvaster";
                }
                else if (equipment2 == false)
                {
                    harvestEquipment = true;
                    equipment2 = true;
                    relicObtained.text = ("You obtained the Harvaster");
                    equip2 = "harvaster";
                }
                else
                {
                    relicObtained.text = ("You obtained the Harvaster");
                    relicReplace.text = "You obtained the Harvaster";
                    replace = "harvaster";
                }
            }
            else if (ruinsItemRandom < ruinsItemTable[2])
            {
                if (equipment1 == false)
                {
                    recyclingCenter = true;
                    equipment1 = true;
                    relicObtained.text = ("You obtained the Recycler");
                    equip1 = "recycler";
                }
                else if (equipment2 == false)
                {
                    recyclingCenter = true;
                    equipment2 = true;
                    relicObtained.text = ("You obtained the Recycler");
                    equip2 = "recycler";
                }
                else
                {
                    relicObtained.text = ("You obtained the Recycler");
                    relicReplace.text = "You obtained the Recycler";
                    replace = "recycler";
                }
            }
            else if (ruinsItemRandom < ruinsItemTable[3])
            {
                if (equipment1 == false)
                {
                    probeBay = true;
                    equipment1 = true;
                    relicObtained.text = ("You obtained the Probe Bay");
                    equip1 = "probeBay";
                }
                else if (equipment2 == false)
                {
                    probeBay = true;
                    equipment2 = true;
                    relicObtained.text = ("You obtained the Probe Bay");
                    equip2 = "probeBay";
                }
                else
                {
                    relicObtained.text = ("You obtained the Probe Bay");
                    relicReplace.text = "You obtained the Probe Bay";
                    replace = "probeBay";
                }
            }
            else if (ruinsItemRandom < ruinsItemTable[4])
            {
                if (equipment1 == false)
                {
                    healingDroneBay = true;
                    equipment1 = true;
                    relicObtained.text = ("You obtained the Healing Drone");
                    equip1 = "healingDrone";
                }
                else if (equipment2 == false)
                {
                    healingDroneBay = true;
                    equipment2 = true;
                    relicObtained.text = ("You obtained the Healing Drone");
                    equip2 = "healingDrone";
                }
                else
                {
                    relicObtained.text = ("You obtained the Healing Drone");
                    relicReplace.text = "You obtained the Healing Drone";
                    replace = "healingDrone";
                }
            }
            else if (ruinsItemRandom < ruinsItemTable[5])
            {
                if (equipment1 == false)
                {
                    lifeSupportBooster = true;
                    equipment1 = true;
                    relicObtained.text = ("You obtained the Life Support Booster");
                    equip1 = "lifeSupportBooster";
                }
                else if (equipment2 == false)
                {
                    lifeSupportBooster = true;
                    equipment2 = true;
                    relicObtained.text = ("You obtained the Life Support Booster");
                    equip2 = "lifeSupportBooster";
                }
                else
                {
                    relicObtained.text = ("You obtained the Life Support Booster");
                    relicReplace.text = "You obtained the Life Support Booster";
                    replace = "lifeSupportBooster";
                }
            }
        }
        else if (ok == 1)
        {
            ruinPanel.SetActive(false);
            ruinPanel2.SetActive(true);
        }
        else if (ok == 2)
        {
            if (equipment1 == true && equipment2 == true)
            {
                if (displayDictionary.ContainsKey(equip1))
                    replacementText1.text = displayDictionary[equip1];

                if (displayDictionary.ContainsKey(equip2))
                    replacementText2.text = displayDictionary[equip2];

                if (inventory >= 1)
                {
                    ruinPanel.SetActive(false);
                    ruinPanel2.SetActive(false);
                    ruinPanel3.SetActive(true);
                }
                else if (inventory < 1)
                {
                    inventory++;
                    Return();
                }
            }
            else
            {
                Return();
            }
        }
    }

    public void EquipmentFull(int equipNumber)
    {
        if (equipNumber == 1)
        {
            equip1 = replace;
        }
        else if (equipNumber == 2)
        {
            equip2 = replace;
        }

        ruinPanel3.SetActive(false);
        shipPanel.SetActive(true);
    }

    public void SaveTimeDilation()
    {
        SaveScript.SavePlayer(this);


        Debug.Log("Saved");
    }

    public void LoadTimeDilation()
    {
        ShipStatsData data = SaveScript.LoadPlayer();

        healthPoint = data.healthPoint;
        planetSensor = data.planetSensor;
        atmosphereSensor = data.atmosphereSensor;
        temperatureSensor = data.temperatureSensor;
        waterSensor = data.waterSensor;
        resourcesSensor = data.resourcesSensor;
        lifeSensor = data.lifeSensor;
        gravitySensor = data.gravitySensor;
        sensorBay = data.sensorBay;
        dataBase = data.dataBase;
        people = data.people;
        fuel = data.fuel;
        equipment1 = data.equipment1;
        equipment2 = data.equipment2;
        equip1 = data.equip1;
        equip2 = data.equip2;
        scoutRadar = data.scoutRadar;
        harvestEquipment = data.harvestEquipment;
        recyclingCenter = data.recyclingCenter;
        probeBay = data.probeBay;
        healingDroneBay = data.harvestEquipment;
        lifeSupportBooster = data.lifeSupportBooster;
    }

    void Update()
    {
        if (equipment1 == false)
            equip1 = "empty";

        if (equipment2 == false)
            equip2 = "empty";

        planetSensorText.text = "Planetary: " + planetSensor;
        atmosphereSensorText.text = "Atmosphere: " + atmosphereSensor;
        temperatureSensorText.text = "Temperature: " + temperatureSensor;
        waterSensorText.text = "Water: " + waterSensor;
        resourcesSensorText.text = "Resources: " + resourcesSensor;
        lifeSensorText.text = "Life: " + lifeSensor;
        gravitySensorText.text = "Gravity: " + gravitySensor;

        if (equipmentDictionary1.ContainsKey(equip1))
            equipmentDisplay1.sprite = equipmentDictionary1[equip1];
        else
            Debug.LogError("Does not contain Key in equipmentDictionary1 " + equip1);

        if (equipmentDictionary2.ContainsKey(equip2))
            equipmentDisplay2.sprite = equipmentDictionary2[equip2];
        else
            Debug.LogError("Does not contain Key in equipmentDictionary2" + equip2);
    }
}
