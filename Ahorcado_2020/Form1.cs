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
        String palabraOculta = eligePalabra();
        Boolean partidaTerminada = false;

        public Form1()
        {
            InitializeComponent();
            String _palabraGuiones = "";
            for (int i = 0; i < palabraOculta.Length; i++)
            {
                if (palabraOculta[i] != ' ')
                {
                    _palabraGuiones += "_ ";
                }
                else
                {
                    _palabraGuiones += "  ";
                }
                palabraGuiones.Text = _palabraGuiones;
            }
        }


        public static String eligePalabra()
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
                for (int i = 0; i < palabraOculta.Length; i++)
                {
                    if (palabraOculta[i] == letra[0])
                    {
                        palabraGuiones.Text = palabraGuiones.Text.Remove(2 * i, 1).Insert(2 * i, letra);
                    }
                }
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
                case -100: pictureBox1.Image = Properties.Resources.acertastetodo; break;
                default: pictureBox1.Image = Properties.Resources.ahorcado_fin1; break;

            }
        }
    }
}