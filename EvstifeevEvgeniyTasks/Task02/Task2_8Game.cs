using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Task2_8Game
    {
        /// <summary>
        /// The game is about a player trying to get all bonuses and avaiding hunting monsters.
        /// There is also obstacles and boundaries of the playable field. The goal is to get all bonuses
        /// to win. 
        /// </summary>
        public class Game {
            /// <summary>
            /// Describes a collision property 
            /// </summary>
            public interface ICollidable
            {
                void Collision<T>(T entity);
            }
            /// <summary>
            /// Describes start menu screen
            /// </summary>
            class StartMenu {
                public StartMenu()
                {
                    //Showing start menu screen
                    //Creating and running a level
                }
            }
            /// <summary>
            /// Describes a screen after losing or winning.
            /// </summary>
            class Finish {
                private void ShowVictoryScreen() 
                { 
                    //Printing congratulations
                }
                private void ShowDefeatScreen() 
                {
                    //Printing Game Over
                }
                /// <summary>
                /// Shows the screen corresponding to final result.
                /// </summary>
                /// <param name="victory"></param>
                public void Finished(bool victory) {
                    if (victory)
                        ShowVictoryScreen();
                    else ShowDefeatScreen();
                }
            }
            /// <summary>
            /// Describes a level which contains every game object.
            /// </summary>
            class Level {
                public Obstacle[] Obstacles = null;
                public Monster[] Monsters = null;
                public Bonus[] Bonuses = null;
                public Field field = null;
                //private bool _finished = false;
                public Level(int countOfMonsters, int countOfBonuses, Obstacle[] obstacles) { 
                    
                }
            }
            /// <summary>
            /// Describes current position on the level of some bonus, monster, obstacle or character 
            /// </summary>
            class Location {
                public double X{ get => X; set => X = value; }
                public double Y { get => Y; set => Y = value; }

                protected Location() { }
                public Location(double x, double y) {
                    this.X = x;
                    this.Y = y;
                }
            }
            /// <summary>
            /// Describes a character with health points, damage, etc.
            /// </summary>
            class Character : Location, ICollidable
            {
                public double HealthPoints { get => (HealthPoints <= 100 && HealthPoints > 0) ? HealthPoints : 0; set => HealthPoints = value; }
                protected double _baseDamage = 1;
                protected double _damageMultiplier = 1;
                public double Damage { get => _baseDamage* _damageMultiplier; }
                public double Speed { get; set; }
                public Location CharacterLocation { get ; set; }
                public Character() { }
                
                public Character(double healthPoints, double damage, double speed, Location location) {
                    HealthPoints = healthPoints;
                    _baseDamage = damage;
                    Speed = speed;
                    CharacterLocation = location;
                }
                protected void Avoid() 
                {
                    
                }
                protected void Move()
                {

                }
                protected void Attack(Character entity)
                {
                    entity.HealthPoints -= this.Damage;
                }
                public virtual void Collision<T>(T entity) 
                {
                    if (entity is ICollidable)
                        if (entity is Obstacle) 
                    {
                        Avoid();
                    } else
                    if (entity is Player || entity is Monster)
                    {
                        Attack(entity as Character);
                    }
                }
            }
            class Player : Character
            {
                public Player() { }
                public override void Collision<T>(T entity) 
                {
                    if (entity is ICollidable) { 
                        base.Collision<T>(entity);
                    if (entity is Bonus)
                    {
                        if (entity is Cherry) 
                            {
                                //Some powerup
                            }
                        else if (entity is Apple) 
                            {
                                //Another powerup
                            }
                            else if (entity is Strawberry) 
                            {
                                //Another powerup
                            }
                    }
                    }
                }
                /// <summary>
                /// Describes the method controlling the player character
                /// </summary>
                public void Control() { 
                    
                }
            }
            class Monster : Character
            {
                /// <summary>
                /// Describes artificial intelligence 
                /// </summary>
                public void AI() { }
            }
            class Wolf : Monster 
            {
                
            }
            class Bear : Monster
            {

            }
            class Crocodile : Monster
            {

            }
            /// <summary>
            /// Describes playable field
            /// </summary>
            class Field 
            {
                public double Width { get => Width; }
                public double Height { get => Height; }
            }
            /// <summary>
            /// Describes bonus on a field
            /// </summary>
            class Bonus : Location, ICollidable
            {
                public void Collision<T>(T entity)
                {
                    if (entity is Player)
                    {
                        Destroy();
                    }
                }
                protected void Destroy() { 
                
                }
            }
            class Cherry : Bonus 
            {

            }
            class Apple : Bonus
            {

            }
            class Strawberry : Bonus
            {

            }
            /// <summary>
            /// Describes obstacle on a field
            /// </summary>
            class Obstacle : Location, ICollidable
            {
                public void Collision<T>(T entity)
                {
                    if (entity is Character)
                    {
                        
                    }
                }
            }
            class Rock : Obstacle
            { 

            }
            class Tree : Obstacle
            {

            }
            class Bush : Obstacle
            {

            }
            class Wall : Obstacle
            {

            }
        }
    }
}
