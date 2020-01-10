using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShipStatsData
{
    public int healthPoint;
    public int planetSensor;
    public int atmosphereSensor;
    public int temperatureSensor;
    public int waterSensor;
    public int resourcesSensor;
    public int lifeSensor;
    public int gravitySensor;
    public int sensorBay;
    public int dataBase;
    public int people;
    public int fuel;

    public bool equipment1;
    public bool equipment2;
    public string equip1;
    public string equip2;

    public bool scoutRadar;
    public bool harvestEquipment;
    public bool recyclingCenter;
    public bool probeBay;
    public bool healingDroneBay;
    public bool lifeSupportBooster;

    public ShipStatsData(Ship ship)
    {
        healthPoint = ship.healthPoint;
        planetSensor = ship.planetSensor;
        atmosphereSensor = ship.atmosphereSensor;
        temperatureSensor = ship.temperatureSensor;
        waterSensor = ship.waterSensor;
        resourcesSensor = ship.resourcesSensor;
        lifeSensor = ship.lifeSensor;
        gravitySensor = ship.gravitySensor;
        sensorBay = ship.sensorBay;
        dataBase = ship.dataBase;
        people = ship.people;
        fuel = ship.fuel;
        equipment1 = ship.equipment1;
        equipment2 = ship.equipment2;
        equip1 = ship.equip1;
        equip2 = ship.equip2;

        scoutRadar = ship.scoutRadar;
        harvestEquipment = ship.harvestEquipment;
        recyclingCenter = ship.recyclingCenter;
        probeBay = ship.probeBay;
        healingDroneBay = ship.harvestEquipment;
        lifeSupportBooster = ship.lifeSupportBooster;
    }
}
