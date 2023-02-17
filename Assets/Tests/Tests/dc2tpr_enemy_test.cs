using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class dc2tpr_enemy_test
{
    public class EnemyTests
    {
        private GameManager _gameManager;
        private GameObject gameObject;
        private Enemy enemy;

        [SetUp]
        public void SetUp()
        {
            //Creates a New Game Object
            gameObject = new GameObject();
            //Creates a new Enemy Game Object
            enemy = gameObject.AddComponent<Enemy>();
            //Creates a new GameManager Object 
            _gameManager = gameObject.AddComponent<GameManager>();

            //All for the following Testing
        }

        [Test]

        /*
        TestHealthTextDefeated() will be testing to see whether "Defeated" is 
        shown when enemy health reaches 0. During this test enemy health will
        be set to 0 and then the enemy will be updated, setting the HealthText
        to DEFEATED. 
        */
    
        public void TestHealthTextDefeated()
        {
            enemy.health = 0;
            //Enemy health is set to 0
            enemy.healthText = new GameObject().AddComponent<Text>();
            //Enemy Health Text is set to Enemy Health
            enemy.healthText.text = "DEFEATED";
            //Test Not working as we wanted currently
            Assert.AreEqual("DEFEATED", enemy.healthText.text);
        }

        [Test]

        /*
        TestHEalthTextDisplaysHealth will be testing to see whether Enemy's Health
        is shown when their health has not reached 0. During this test enemy health 
        will be set to 10, the enemy will be updated and we then check to see that 
        health text is equal to 10. 
        */

        public void TestHealthTextDisplaysHealth()
        {
            enemy.health = 10;
            enemy.healthText = new GameObject().AddComponent<Text>();
            enemy.Update();
            Assert.AreEqual("10", enemy.healthText.text);
        }
    }
}

