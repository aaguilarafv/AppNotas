﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO; //Se agrega
namespace AppGitNotas
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        string archivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notas.txt");
        public MainPage()
        {
            InitializeComponent();

            if(File.Exists(archivo))
            {
                txteditor.Text = File.ReadAllText(archivo);
            }
        }

        private void btnGrabar_Clicked(object sender, EventArgs e)
        {
            try
            {

            
            File.WriteAllText(archivo, txteditor.Text);
            DisplayAlert("Exito", "Archivo grabado con éxito", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            if(File.Exists(archivo))
            {
                try 
                { 

                File.Delete(archivo);
                txteditor.Text = string.Empty;
                DisplayAlert("Exito", "Archivo eliminado con éxito", "OK");
                }
                catch (Exception ex)
                {
                    DisplayAlert("Error", ex.Message, "OK");
                }
            }
            
        }
    }
}
