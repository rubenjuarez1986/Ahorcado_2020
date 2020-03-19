using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorcado_2020
{
    public partial class Form1 : Form
    {
        int numFallos = 0;
        String palabraOculta = "CETYS";
        Boolean partidaTerminada = false;

        public Form1()
        {
            InitializeComponent();
        }


        public String eligePalabra()
        {
            String[] listaPalabras = { "HOLA", "MOÑECA", "OTOBUS","ESPATATRAPO", "COBETE","INDICION" };
            Random aleatorio = new Random();
            int pos = aleatorio.Next(listaPalabras.Length);
            return listaPalabras[pos].ToUpper();
        }

        private void letraPulsada(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            String letra = boton.Text;
            letra = letra.ToUpper();

            if (palabraOculta.Contains(letra))
            {
                int posicion = palabraOculta.IndexOf(letra);
                palabraGuiones.Text = palabraGuiones.Text.Remove(2 * posicion, 1).Insert(2 * posicion, letra);
            }
            else
            {
                numFallos++;
            }
            if (!palabraGuiones.Text.Contains('_'))
            {
                numFallos = -100;
            }
            switch (numFallos)
            {
                case 0: pictureBox1.Image = Properties.Resources.ahorcado_0; break;
                case 1: pictureBox1.Image = Properties.Resources.ahorcado_1; break;
                case 2: pictureBox1.Image = Properties.Resources.ahorcado_2; break;
                case 3: pictureBox1.Image = Properties.Resources.ahorcado_3; break;
                case 4: pictureBox1.Image = Properties.Resources.ahorcado_4; break;
                case 5: pictureBox1.Image = Properties.Resources.ahorcado_5; break;
                case 6: pictureBox1.Image = Properties.Resources.ahorcado_fin1; break;
                case -100: pictureBox1.Image = Properties.Resources.homer; break;
                default: pictureBox1.Image = Properties.Resources.ahorcado_fin; break;

            }
        }

        
    }
}
