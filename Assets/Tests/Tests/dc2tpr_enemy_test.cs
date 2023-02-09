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
            gameObject = new GameObject();
            enemy = gameObject.AddComponent<Enemy>();
            _gameManager = gameObject.AddComponent<GameManager>();
        }

        [Test]
        public void HealthTextDefeatedWhenZero()
        {
            enemy.health = 0;
            enemy.healthText = new GameObject().AddComponent<Text>();
            enemy.healthText.text = "DEFEATED";
            Assert.AreEqual("DEFEATED", enemy.healthText.text);
        }

        [Test]
        public void HealthTextDisplaysHealthWhenNotZero()
        {
            enemy.health = 10;
            enemy.healthText = new GameObject().AddComponent<Text>();
            enemy.Update();
            Assert.AreEqual("10", enemy.healthText.text);
        }
    }
}

