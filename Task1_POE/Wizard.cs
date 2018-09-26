using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1_POE
{
    class Wizard : Unit
    {
        public string Name
        {
            get { return name; }
            set { name = value; }

        }


        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public bool Alive
        {
            get { return alive; }
            set { alive = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public int AttackRange
        {
            get { return attackRange; }
            set { attackRange = value; }
        }

        public string Team
        {
            get { return team; }
            set { team = value; }
        }

        public char Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        public override void Combat(Unit enemy)
        {

           // MessageBox.Show("wizard combat "+ team );
            if (enemy.attackRange == 4)
            {

                RangedUnit cEnemy = (RangedUnit)enemy;
                cEnemy.team = this.team;
               
            }
            else if (enemy.attackRange == 2)
            {

                MeleeUnit cEnemy = (MeleeUnit)enemy;
                cEnemy.team = this.team;

            }
            else
            {
                Wizard cEnemy = (Wizard)enemy;
                cEnemy.team = this.team;
            }
        }

        public override int FindUnit(Unit enemy)
        {
            int distance;
            if (enemy.attackRange == 4)
            {

                RangedUnit cEnemy = (RangedUnit)enemy;

                distance = (Math.Abs(x - cEnemy.X) + Math.Abs(y - cEnemy.Y));
            }
            else if (enemy.attackRange == 2)
            {

                MeleeUnit cEnemy = (MeleeUnit)enemy;
                distance = (Math.Abs(x - cEnemy.X) + Math.Abs(y - cEnemy.Y));

            }
            else
            {
                Wizard cEnemy = (Wizard)enemy;
                distance = (Math.Abs(x - cEnemy.X) + Math.Abs(y - cEnemy.Y));
            }



            //MessageBox.Show(distance.ToString() + enemy.ToString());
            return distance;

        }

        public override Unit constuctor(int rX, int rY, int team)
        {
            Wizard wizard = new Wizard();
            wizard.name = "Wizard";
            wizard.AttackRange = 3;
            wizard.health = 5;
            wizard.X = rX;
            wizard.Y = rY;            
            wizard.Speed = 1;
            wizard.symbol = 'W';

            switch (team)
            {
                case 1:
                    wizard.team = "Blue";
                    //   teamColour="Blue";
                    break;

                case 2:
                    wizard.team = "Yellow";
                    // teamColour = "Green";
                    break;

            }// team assigning

            return wizard;
          
        }

        public override bool Death()
        {
            if (health > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void MoveUnit(int mx, int my)
        {
           // MessageBox.Show(mx.ToString() + " "+ my.ToString()+ " "+ team);
            if ((mx + speed < 20) && (mx - speed < 0) && (my + speed < 20) && (my - speed < 0))
            {
                if (mx > 0 && mx + speed < 20)
                {
                    x = x + speed;
                }
                else if (mx < 0)
                {
                    x = x - speed;
                }

                if (my > 0)
                {
                    y = y + speed;
                }
                else if (my < 0)
                {
                    y = y - speed;
                }
            }
        }

        public override Unit ReturnPosition(MeleeUnit[] enemyM, RangedUnit[] enemyR)
        {
            MeleeUnit MEnemy = null;
            RangedUnit rEnemy = null;
            int count = 0;

            int distance = 0;
            int distancer = 0;




            foreach (MeleeUnit u in enemyM)
            {
                if (u != null)
                {
                    if (u.Alive && u.team != team)
                    {
                        if (u.X != x && u.Y != y)
                        {
                            if (count == 0)
                            {
                                count++;
                                distance = ((Math.Abs(x) - Math.Abs(u.X)) + (Math.Abs(y) - Math.Abs(u.Y)));
                            }
                            else
                            {
                                if (distance > ((Math.Abs(x) - Math.Abs(u.X)) + (Math.Abs(y) - Math.Abs(u.Y))))
                                {
                                    distance = ((Math.Abs(x) - Math.Abs(u.X)) + (Math.Abs(y) - Math.Abs(u.Y)));

                                    MEnemy = u;
                                }

                            }
                        }
                    }
                }



            }
            count = 0;
            foreach (RangedUnit u in enemyR)
            {
                if (u != null)
                {
                    if (u.Alive && u.team != team)
                    {
                        if (u.X != x && u.Y != y)
                        {
                            if (count == 0)
                            {
                                count++;
                                distancer = ((Math.Abs(x) - Math.Abs(u.X)) + (Math.Abs(y) - Math.Abs(u.Y)));

                                rEnemy = u;
                            }
                            if (distancer > ((Math.Abs(x) - Math.Abs(u.X)) + (Math.Abs(y) - Math.Abs(u.Y))))
                            {
                                distancer = ((Math.Abs(x) - Math.Abs(u.X)) + (Math.Abs(y) - Math.Abs(u.Y)));
                                rEnemy = u;

                            }


                        }
                    }
                }



            }

            //MessageBox.Show(rEnemy.ToString());
            if (distance > distancer)
            {
                return rEnemy;
                
            }
            else
            {
                return MEnemy;
            }


        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string Info;
            Info = "Name: " + name + "\n";
            Info = Info + "x: " + x + "\n";
            Info = Info + "y: " + y + "\n";
            Info = Info + "Health: " + health + "\n";
            Info = Info + "Speed: " + speed + "\n";
            Info = Info + "Attack Range: " + AttackRange + "\n";
            Info = Info + "Team" + team + "\n";
            Info = Info + "Symbol: " + symbol + "\n";
            return Info;
        }
    }
}
