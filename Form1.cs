using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
//Libreria Codigo de Barras
using ZXing;

namespace CodigoDeBarras
{
    public partial class Form1 : Form
    {
        public static string cadena = "Server=CARAPRCTIFSD163\\SQLEXPRESS;Database=Datos;User Id=ADSI2278769;Password=12345;";
        public static SqlConnection conexion = new SqlConnection(cadena);
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                MessageBox.Show("Hola");
            }
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            string ruta = Application.StartupPath + "\\CodBarras.bmp";
                // instancia de la funcion de la libreria Zxing
                var barcodeWriter = new BarcodeWriter();

            // set the barcode format
            barcodeWriter.Format = BarcodeFormat.CODE_128;

            // write text and generate a 2-D barcode as a bitmap
            barcodeWriter
                .Write(TxtCodBarra.Text)
                .Save(Application.StartupPath + "\\CodBarras.bmp");

                //muestro en el picture box
                PBCodBarra.Image=Image.FromFile(ruta);
        }

        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            SqlCommand comando = new SqlCommand("PA_INSERTARCODBAR", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", TxtCodBarra.Text);
            string ruta = Application.StartupPath + "\\CodBarras.bmp";
            Image ImagenCodBar = Image.FromFile(ruta);
            //Convertir a uun arreglo de byte
            MemoryStream ms;
            ms = new MemoryStream();
            ImagenCodBar.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] photo_aray = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(photo_aray, 0, photo_aray.Length);
            comando.Parameters.AddWithValue("@IMAGEN", photo_aray);
            //ejecutar
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("Imagen de codigo de barras insertada");
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            TxtCodBarra.Clear();
        }

        private void TxtBuscarCodBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            SqlDataAdapter comando = new SqlDataAdapter("PA_TRAERIMAGENCODBAR", conexion);
            comando.SelectCommand.CommandType = CommandType.StoredProcedure;
            comando.SelectCommand.Parameters.AddWithValue("@id", TxtBuscarCodBarra.Text);
            DataTable tabla = new DataTable();
            comando.Fill(tabla);
            //capturo el arreglo de bytes
            byte[] photo_aray = (byte[])tabla.Rows[0]["imagen"];
            ///convierte los bytes a una imagen
            MemoryStream ms=new MemoryStream(photo_aray);
            Bitmap bmp = null;
            bmp= new Bitmap(ms);
            //Muestro la imagen
            PBCodBarra.Image=bmp;
            MessageBox.Show("Imagen de codigo de barras insertada");
        }
    }
}
