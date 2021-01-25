using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        //tauler del 3 en ralla
        public string[] ralla = { " ", " ", " ", " ", " ", " ", " ", " ", " " };
        //posicions jugades pel jugador 1
        public int[] jugador1 = { -1, -1, -1 };
        //posicions jugades pel jugador 2
        public int[] jugador2 = { -1, -1, -1 };
        //true = jugador1 i false=jugador2
        bool jugador = true;
        //boto que juga el jugador
        public int num_button = -1;
        //resultat de la partida
        bool guanyador = false;
        //fixes jugades per jugador
        int count = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            mostrar_text(textBox1.Text);
            
            if (!radioButton1.Checked && !radioButton3.Checked)
            {
                while (!guanyador)
                {
                    jugades_jugador_1();                    

                    Thread.Sleep(500);
                    this.Refresh();

                    if (!guanyador)
                        jugades_jugador_2();                   

                    Thread.Sleep(500);
                    this.Refresh();
                }
            }
            else if (!radioButton1.Checked)
            {
                jugades_jugador_1();
            }
        }

        public void jugades_jugador_1()
        {
            if (radioButton1.Checked)
            {
                if (jugador1[2] == -1)
                {
                    jugador1[count] = num_button;

                    //escribim el simbol a la posicio
                    escriure_num(num_button, jugador);

                    //canvi jugador
                    jugador = false;
                }
                else
                {
                    // redisenyem el tauler i les jugades del jugador
                    jugador1 = redisenyar(jugador1);

                    jugador1[2] = num_button;

                    //escribim el simbol a la posicio
                    escriure_num(num_button, jugador);

                    guanyador = check_resutat();

                    //canvi jugador
                    jugador = false;
                }
            }
            else
            {
                if (jugador1[2] == -1)
                {
                    //generar una posicio random lliure
                    int num = generar_posicio();
                    while (num == -1)
                    {
                        num = generar_posicio();
                    }
                    jugador1[count] = num;

                    //escribim el simbol a la posicio
                    escriure_num(num, jugador);

                    //canvi jugador
                    jugador = false;
                }
                else
                {
                    // redisenyem el tauler i les jugades del jugador
                    jugador1 = redisenyar(jugador1);

                    //generar una posicio random lliure
                    int num = generar_posicio();
                    while (num == -1)
                    {
                        num = generar_posicio();
                    }

                    jugador1[2] = num;

                    //escribim el simbol a la posicio
                    escriure_num(num, jugador);

                    guanyador = check_resutat();

                    //canvi jugador
                    jugador = false;
                }
            }
        }

        public void jugades_jugador_2()
        {
            if (radioButton3.Checked)
            {
                if (jugador2[2] == -1)
                {


                    jugador2[count] = num_button;

                    //escribim el simbol a la posicio
                    escriure_num(num_button, jugador);

                    //canvi jugador
                    jugador = true;

                    //incrementem el contador de posicions
                    count++;
                }
                else
                {
                    // redisenyem el tauler i les jugades del jugador
                    jugador2 = redisenyar(jugador2);



                    jugador2[2] = num_button;

                    //escribim el simbol a la posicio
                    escriure_num(num_button, jugador);

                    guanyador = check_resutat();

                    //canvi jugador
                    jugador = true;
                }
            }
            else
            {
                if (jugador2[2] == -1)
                {
                    //generar una posicio random lliure
                    int num = generar_posicio();
                    while (num == -1)
                    {
                        num = generar_posicio();
                    }
                    jugador2[count] = num;

                    //escribim el simbol a la posicio
                    escriure_num(num, jugador);

                    //canvi jugador
                    jugador = true;

                    //incrementem el contador de posicions
                    count++;
                }
                else
                {
                    // redisenyem el tauler i les jugades del jugador
                    jugador2 = redisenyar(jugador2);

                    //generar una posicio random lliure
                    int num = generar_posicio();
                    while (num == -1)
                    {
                        num = generar_posicio();
                    }

                    jugador2[2] = num;

                    //escribim el simbol a la posicio
                    escriure_num(num, jugador);

                    guanyador = check_resutat();

                    //canvi jugador
                    jugador = true;
                }               
            }
        }
            
        public void mostrar_text (string e)
        {
            string frase1 = e + ", coloca ficha ...";

            label2.Text = frase1;
        }

        public bool check_resutat()
        {
            if (ralla[0].Equals(ralla[1]) && ralla[0].Equals(ralla[2]) && !ralla[0].Equals(" "))
            {
                if (ralla[0].Equals("X"))
                {
                    label2.Text = textBox1.Text + " ha guanyat!!!!";
                    return true;
                }
                else
                {
                    label2.Text = textBox2.Text + " ha guanyat!!!!";
                    return true;
                }
            }
            if (ralla[3].Equals(ralla[4]) && ralla[3].Equals(ralla[5]) && !ralla[3].Equals(" "))
            {
                if (ralla[3].Equals("X"))
                {
                    label2.Text = textBox1.Text + " ha guanyat!!!!";
                    return true;
                }
                else
                {
                    label2.Text = textBox2.Text + " ha guanyat!!!!";
                    return true;
                }
            }
            if (ralla[6].Equals(ralla[7]) && ralla[6].Equals(ralla[8]) && !ralla[6].Equals(" "))
            {
                if (ralla[6].Equals("X"))
                {
                    label2.Text = textBox1.Text + " ha guanyat!!!!";
                    return true;
                }
                else
                {
                    label2.Text = textBox2.Text + " ha guanyat!!!!";
                    return true;
                }
            }
            if (ralla[0].Equals(ralla[3]) && ralla[0].Equals(ralla[6]) && !ralla[0].Equals(" "))
            {
                if (ralla[0].Equals("X"))
                {
                    label2.Text = textBox1.Text + " ha guanyat!!!!";
                    return true;
                }
                else
                {
                    label2.Text = textBox2.Text + " ha guanyat!!!!";
                    return true;
                }
            }
            if (ralla[1].Equals(ralla[4]) && ralla[1].Equals(ralla[7]) && !ralla[1].Equals(" "))
            {
                if (ralla[1].Equals("X"))
                {
                    label2.Text = textBox1.Text + " ha guanyat!!!!";
                    return true;
                }
                else
                {
                    label2.Text = textBox2.Text + " ha guanyat!!!!";
                    return true;
                }
            }
            if (ralla[2].Equals(ralla[5]) && ralla[2].Equals(ralla[8]) && !ralla[2].Equals(" "))
            {
                if (ralla[2].Equals("X"))
                {
                    label2.Text = textBox1.Text + " ha guanyat!!!!";
                    return true;
                }
                else
                {
                    label2.Text = textBox2.Text + " ha guanyat!!!!";
                    return true;
                }
            }
            if (ralla[0].Equals(ralla[4]) && ralla[0].Equals(ralla[8]) && !ralla[0].Equals(" "))
            {
                if (ralla[0].Equals("X"))
                {
                    label2.Text = textBox1.Text + " ha guanyat!!!!";
                    return true;
                }
                else
                {
                    label2.Text = textBox2.Text + " ha guanyat!!!!";
                    return true;
                }
            }
            if (ralla[2].Equals(ralla[4]) && ralla[2].Equals(ralla[6]) && !ralla[2].Equals(" "))
            {
                if (ralla[2].Equals("X"))
                {
                    label2.Text = textBox1.Text + " ha guanyat!!!!";
                    return true;
                }
                else
                {
                    label2.Text = textBox2.Text + " ha guanyat!!!!";
                    return true;
                }
            }

            return false;
        }

        public int[] redisenyar (int[] jugador)
        {
            ralla[jugador[0]] = " ";

            switch (jugador[0])
            {
                case 0:
                    button1.Text = " ";
                    break;
                case 1:
                    button2.Text = " ";
                    break;
                case 2:
                    button3.Text = " ";
                    break;
                case 3:
                    button4.Text = " ";
                    break;
                case 4:
                    button5.Text = " ";
                    break;
                case 5:
                    button6.Text = " ";
                    break;
                case 6:
                    button7.Text = " ";
                    break;
                case 7:
                    button8.Text = " ";
                    break;
                case 8:
                    button9.Text = " ";
                    break;
            }

            jugador[0] = jugador[1];
            jugador[1] = jugador[2];
            jugador[2] = -1;

            return jugador;
        }

        public int generar_posicio()
        {
            Random rnd = new Random();
            int num = rnd.Next(0, 9);
            if (ralla[num].Equals(" "))
            {
                return num;
            }
            else
            {
                return -1;
            }
            
        }

        public void escriure_num(int num, bool jugador)
        {
            string simbol = null;
            switch (num)
            {
                case 0:
                    if (jugador)
                        simbol = "X";
                    else
                        simbol = "O";
                    button1.Text = simbol;
                    ralla[0] = simbol;
                    break;
                case 1:
                    if (jugador)
                        simbol = "X";
                    else
                        simbol = "O";
                    button2.Text = simbol;
                    ralla[1] = simbol;
                    break;
                case 2:
                    if (jugador)
                        simbol = "X";
                    else
                        simbol = "O";
                    button3.Text = simbol;
                    ralla[2] = simbol;
                    break;
                case 3:
                    if (jugador)
                        simbol = "X";
                    else
                        simbol = "O";
                    button4.Text = simbol;
                    ralla[3] = simbol;
                    break;
                case 4:
                    if (jugador)
                        simbol = "X";
                    else
                        simbol = "O";
                    button5.Text = simbol;
                    ralla[4] = simbol;
                    break;
                case 5:
                    if (jugador)
                        simbol = "X";
                    else
                        simbol = "O";
                    button6.Text = simbol;
                    ralla[5] = simbol;
                    break;
                case 6:
                    if (jugador)
                        simbol = "X";
                    else
                        simbol = "O";
                    button7.Text = simbol;
                    ralla[6] = simbol;
                    break;
                case 7:
                    if (jugador)
                        simbol = "X";
                    else
                        simbol = "O";
                    button8.Text = simbol;
                    ralla[7] = simbol;
                    break;
                case 8:
                    if (jugador)
                        simbol = "X";
                    else
                        simbol = "O";
                    button9.Text = simbol;
                    ralla[8] = simbol;
                    break;               
            }
        }

        public void button10_Click(object sender, EventArgs e)
        {
            ralla[0]= " "; ralla[1] = " "; ralla[2] = " "; ralla[3] = " "; ralla[4] = " "; ralla[5] = " "; ralla[6] = " "; ralla[7] = " "; ralla[8] = " ";
            jugador1[0] = -1; jugador1[1] = -1; jugador1[2] = -1;
            jugador2[0] = -1; jugador2[1] = -1; jugador2[2] = -1;
            label2.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
            count = 0;
            jugador = true;
            guanyador = false;
            num_button = -1;
        }

        public void button1_Click(object sender, EventArgs e)
        {        
            if (jugador && radioButton1.Checked)
            {
                num_button = 0;
                jugades_jugador_1();
                if (!radioButton3.Checked)
                    jugades_jugador_2();
                else
                    mostrar_text(textBox2.Text);
            }               
            else if (!jugador && radioButton3.Checked)
            {
                num_button = 0;
                jugades_jugador_2();
                if (!radioButton1.Checked)
                    jugades_jugador_1();
                else
                    mostrar_text(textBox1.Text);
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            num_button = 1;
            if (jugador && radioButton1.Checked)
            {
                jugades_jugador_1();
                if (!radioButton3.Checked)
                    jugades_jugador_2();
                else
                    mostrar_text(textBox2.Text);
            }
            else if (!jugador && radioButton3.Checked)
            {                
                jugades_jugador_2();
                if (!radioButton1.Checked)
                    jugades_jugador_1();
                else
                    mostrar_text(textBox1.Text);
            }
        }

        public void button3_Click(object sender, EventArgs e)
        {
            num_button = 2;
            if (jugador && radioButton1.Checked)
            {
                jugades_jugador_1();
                if (!radioButton3.Checked)
                    jugades_jugador_2();
                else
                    mostrar_text(textBox2.Text);
            }
            else if (!jugador && radioButton3.Checked)
            {                
                jugades_jugador_2();
                if (!radioButton1.Checked)
                    jugades_jugador_1();
                else
                    mostrar_text(textBox1.Text);
            }
        }

        public void button4_Click(object sender, EventArgs e)
        {
            num_button = 3;
            if (jugador && radioButton1.Checked)
            {                
                jugades_jugador_1();
                if (!radioButton3.Checked)
                    jugades_jugador_2();
                else
                    mostrar_text(textBox2.Text);
            }
            else if (!jugador && radioButton3.Checked)
            {
                jugades_jugador_2();
                if (!radioButton1.Checked)
                    jugades_jugador_1();
                else
                    mostrar_text(textBox1.Text);
            }
        }

        public void button5_Click(object sender, EventArgs e)
        {
            num_button = 4;
            if (jugador && radioButton1.Checked)
            {
                jugades_jugador_1();
                if (!radioButton3.Checked)
                    jugades_jugador_2();
                else
                    mostrar_text(textBox2.Text);
            }
            else if (!jugador && radioButton3.Checked)
            {                
                jugades_jugador_2();
                if (!radioButton1.Checked)
                    jugades_jugador_1();
                else
                    mostrar_text(textBox1.Text);
            }
        }

        public void button6_Click(object sender, EventArgs e)
        {
            num_button = 5;
            if (jugador && radioButton1.Checked)
            {
                jugades_jugador_1();
                if (!radioButton3.Checked)
                    jugades_jugador_2();
                else
                    mostrar_text(textBox2.Text);
            }
            else if (!jugador && radioButton3.Checked)
            {                
                jugades_jugador_2();
                if (!radioButton1.Checked)
                    jugades_jugador_1();
                else
                    mostrar_text(textBox1.Text);
            }
        }

        public void button7_Click(object sender, EventArgs e)
        {
            num_button = 6;
            if (jugador && radioButton1.Checked)
            {               
                jugades_jugador_1();
                if (!radioButton3.Checked)
                    jugades_jugador_2();
                else
                    mostrar_text(textBox2.Text);
            }
            else if (!jugador && radioButton3.Checked)
            {                
                jugades_jugador_2();
                if (!radioButton1.Checked)
                    jugades_jugador_1();
                else
                    mostrar_text(textBox1.Text);
            }
        }

        public void button8_Click(object sender, EventArgs e)
        {
            num_button = 7;
            if (jugador && radioButton1.Checked)
            {                
                jugades_jugador_1();
                if (!radioButton3.Checked)
                    jugades_jugador_2();
                else
                    mostrar_text(textBox2.Text);
            }
            else if (!jugador && radioButton3.Checked)
            {                
                jugades_jugador_2();
                if (!radioButton1.Checked)
                    jugades_jugador_1();
                else
                    mostrar_text(textBox1.Text);
            }
        }

        public void button9_Click(object sender, EventArgs e)
        {
            num_button = 8;
            if (jugador && radioButton1.Checked)
            {              
                jugades_jugador_1();
                if (!radioButton3.Checked)
                    jugades_jugador_2();
                else
                    mostrar_text(textBox2.Text);
            }
            else if (!jugador && radioButton3.Checked)
            {                
                jugades_jugador_2();
                if (!radioButton1.Checked)
                    jugades_jugador_1();
                else
                    mostrar_text(textBox1.Text);
            }
        }
    }
}
