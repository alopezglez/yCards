using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yCards
{
    public partial class Form1 : Form
    {

        int c1;
        int c2;
        int c3;
        int c4;
        int CartaArriba_1;
        int CartaArriba_2;
        int CartasArriba = 0;
        int Intentos = 2;
        string Ganado = "Perfecto - Conseguido !!";
        string Perdido = "Vaya - Has Perdido !!";

        public Form1()
        {
            InitializeComponent();
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btReiniciar_Click(object sender, EventArgs e)
        {
            var rnd = new Random();
            c1 = rnd.Next(0, 4);
            c2 = rnd.Next(0, 4);
            c3 = rnd.Next(0, 4);
            c4 = rnd.Next(0, 4);

            while (c2 == c1)
            {
                c2 = rnd.Next(0, 4);
            }

            while (c3 == c2 || c3 == c1)
            {
                c3 = rnd.Next(0, 4);
            }

            while (c4 != c3 && c4 != c2 && c4 != c1)
            {
                c4 = rnd.Next(0, 4);
            }

            //(Re)inicializa variables y contador
            Intentos = 2;
            lblMarcador.Text = Intentos.ToString();
            CartasArriba = 0;

            VoltearCartas();


        }

        private void Carta_1_Click(object sender, EventArgs e)
        {

            switch (c1)
            {
                case 0:
                    Carta_1.Image = p1.Image;
                    break;

                case 1:
                    Carta_1.Image = p2.Image;
                    break;

                case 2:
                    Carta_1.Image = p3.Image;
                    break;

                case 3:
                    Carta_1.Image = p4.Image;
                    break;

            }

            if (CartasArriba == 0)
            {
                CartaArriba_1 = 1; //Si no hay cartas hacia arriba esta será la primera
            }
            else if (CartasArriba == 1)
            {
                CartaArriba_2 = 1; //Si ya hay otra carta hacia arriba esta será la segunda
            }

            ContarCartas();

        }

        private void Carta_2_Click(object sender, EventArgs e)
        {

            switch (c2)
            {
                case 0:
                    Carta_2.Image = p1.Image;
                    break;

                case 1:
                    Carta_2.Image = p2.Image;
                    break;

                case 2:
                    Carta_2.Image = p3.Image;
                    break;

                case 3:
                    Carta_2.Image = p4.Image;
                    break;

            }

            if (CartasArriba == 0)
            {
                CartaArriba_1 = 2; //Si no hay cartas hacia arriba esta será la primera
            }
            else if (CartasArriba == 1)
            {
                CartaArriba_2 = 2; //Si ya hay otra carta hacia arriba esta será la segunda
            }

            ContarCartas();

        }

        private void Carta_3_Click(object sender, EventArgs e)
        {

            switch (c3)
            {
                case 0:
                    Carta_3.Image = p1.Image;
                    break;

                case 1:
                    Carta_3.Image = p2.Image;
                    break;

                case 2:
                    Carta_3.Image = p3.Image;
                    break;

                case 3:
                    Carta_3.Image = p4.Image;
                    break;

            }

            if (CartasArriba == 0)
            {
                CartaArriba_1 = 3; //Si no hay cartas hacia arriba esta será la primera
            }
            else if (CartasArriba == 1)
            {
                CartaArriba_2 = 3; //Si ya hay otra carta hacia arriba esta será la segunda
            }

            ContarCartas();

        }

        private void Carta_4_Click(object sender, EventArgs e)
        {

            switch (c4)
            {
                case 0:
                    Carta_4.Image = p1.Image;
                    break;

                case 1:
                    Carta_4.Image = p2.Image;
                    break;

                case 2:
                    Carta_4.Image = p3.Image;
                    break;

                case 3:
                    Carta_4.Image = p4.Image;
                    break;

            }

            if (CartasArriba == 0)
            {
                CartaArriba_1 = 4; //Si no hay cartas hacia arriba esta será la primera
            }
            else if (CartasArriba == 1)
            {
                CartaArriba_2 = 4; //Si ya hay otra carta hacia arriba esta será la segunda
            }

            ContarCartas();

        }

        void VoltearCartas()
        {
            Carta_1.Image = p5.Image;
            Carta_2.Image = p5.Image;
            Carta_3.Image = p5.Image;
            Carta_4.Image = p5.Image;
            lblResult.Visible = false;

        }

        void ContarCartas()
        {
            CartasArriba++;
            Application.DoEvents(); //Obliga a la segunda carta a destaparse, la función Sleep congela la App


            // Si ya hay dos cartas al descubierto, hace comprobaciones
            if (CartasArriba >= 2)
            {
                //Resta un intento
                Intentos--;
                lblMarcador.Text = Intentos.ToString();

                //Pequeña pausa para queno sea tan instantaneo
                System.Threading.Thread.Sleep(2000);

                switch (CartaArriba_1)
                {
                    case 1:
                        Comparar_1.Image = Carta_1.Image;
                        break;
                    case 2:
                        Comparar_1.Image = Carta_2.Image;
                        break;
                    case 3:
                        Comparar_1.Image = Carta_3.Image;
                        break;
                    case 4:
                        Comparar_1.Image = Carta_4.Image;
                        break;

                }

                switch (CartaArriba_2)
                {
                    case 1:
                        Comparar_2.Image = Carta_1.Image;
                        break;
                    case 2:
                        Comparar_2.Image = Carta_2.Image;
                        break;
                    case 3:
                        Comparar_2.Image = Carta_3.Image;
                        break;
                    case 4:
                        Comparar_2.Image = Carta_4.Image;
                        break;

                }

                if (Comparar_1.Image == Comparar_2.Image)
                {
                    lblResult.Visible = true;
                    lblResult.Text = Ganado;

                    Application.DoEvents();
                    System.Threading.Thread.Sleep(2000);

                    btReiniciar.PerformClick();
                }
                else
                {
                    if (Intentos == 0)
                    {
                        lblResult.Visible = true;
                        lblResult.Text = Perdido;

                        Application.DoEvents();
                        System.Threading.Thread.Sleep(2000);

                        btReiniciar.PerformClick();

                    }
                }

                // Vuelve a voltear las cartas y reinicia el contador

                CartasArriba = 0;
                VoltearCartas();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btReiniciar.PerformClick();
        }
    }
}
