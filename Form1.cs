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
//Libreria Codigo de Barras
using ZXing;
using System.Data.SqlClient;

namespace CodigoDeBarras
{
    public partial class Form1 : Form
    {
        public static string cadena = "Server=CARAPRCTIFSD152\\SQLEXPRESS;Database=Datos;User Id=ADSI2278769;Password=12345;";
        public static SqlConnection conexion = new SqlConnection(cadena);
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            string Ruta = Application.StartupPath + "\\Codbarras.bmp";
            if (File.Exists(Ruta))
            {
                // instancia de la función de la libreria Zxing
                var barcodeWriter = new BarcodeWriter();
                barcodeWriter.Format = BarcodeFormat.CODE_128;
                barcodeWriter
                    .Write(TxtCodBarra.Text)
                    .Save(Application.StartupPath + "\\Codbarras.bmp");
                //muestro en el picture box
                PBCodBarra.Image = Image.FromFile(Ruta);
            }
        }

        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            SqlCommand comando = new SqlCommand("PA_INSERTARCODBAR", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ID", TxtCodBarra.Text);
            string Ruta = Application.StartupPath + "\\Codbarras.bmp";
            Image imagenCodbar = Image.FromFile(Ruta);
            //convertir a un arreglo de byte
            MemoryStream ms;
            ms = new MemoryStream();
            imagenCodbar.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] photo_aray = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(photo_aray, 0, photo_aray.Length);
            comando.Parameters.AddWithValue("@Imagen", photo_aray);
            //ejecutar
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("Imagen Codigo de Barras Insertada");
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            PBCodBarra.Image = null;
        }

        private void TxtBuscarCodBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SqlConnection cnn = new SqlConnection(cadena);
                SqlDataAdapter adap = new SqlDataAdapter("PA_TRAERIMAGENCODBAR", cnn);
                adap.SelectCommand.CommandType = CommandType.StoredProcedure;
                adap.SelectCommand.Parameters.AddWithValue("@ID", TxtBuscarCodBarra.Text);
                DataTable tabla = new DataTable();
                adap.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    //capturo el arreglo de bytes
                    byte[] photo_aray = (byte[])tabla.Rows[0]["Imagen"];
                    //convierto los bytes a una imagen
                    MemoryStream ms = new MemoryStream(photo_aray);
                    Bitmap bm = null;
                    bm = new Bitmap(ms);
                    //muestro la imagen
                    PBCodBarra.Image = bm;
                    MessageBox.Show("Encontrado");
                }
                else
                {
                    MessageBox.Show("NO Encontrado");
                }
            }
        }
        //Terminado
    }
}
