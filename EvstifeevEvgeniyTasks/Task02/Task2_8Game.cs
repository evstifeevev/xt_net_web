using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Task2_8Game
    {
        public class Game {
            public interface ICollidable
            {
                void Collision<T>(T entity);
            }
            class Location {
                public double X{ get => X; set => X = value; }
                public double Y { get => Y; set => Y = value; }

                protected Location() { }
                public Location(double x, double y) {
                    this.X = x;
                    this.Y = y;
                }
            }
            class Character : Location, ICollidable
            {
                public double HealthPoints { get => (HealthPoints <= 100 && HealthPoints > 0) ? HealthPoints : 0; set => HealthPoints = value; }
                protected double _baseDamage = 1;
                protected double _damageMultiplier = 1;
                public double Damage { get => _baseDamage* _damageMultiplier; }
                public double Speed { get => Speed; set => Speed = value; }
                public Location CharacterLocation { get => CharacterLocation; set => CharacterLocation = value; }
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
                        if (entity is Cherry) { }
                        else if (entity is Apple) { }
                        else if (entity is Apple) { }
                    }
                    }
                }
            }
            class Monster : Character
            { 
            
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
            class Field 
            {
                public double Width { get => Width; }
                public double Height { get => Height; }
            }
            class Bonus : Location, ICollidable
            {
                public void Collision<T>(T entity)
                {
                    if (entity is Player)
                    {
                        //PowerUp();
                    }
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
