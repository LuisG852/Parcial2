using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcialDos
{
    public partial class Form1 : Form
    {

        private string[] ArregloNotas;

        public Form1()
        {
            InitializeComponent();
        }

        //Carga de .CSV a la aplicacion.
        private void buttonCargarArchivo_Click(object sender, EventArgs e)
        {
            ClsArchivo ar = new ClsArchivo();

            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Selecciona un archivo .CSV";
            ofd.InitialDirectory = @"C:\Users\georg\source\repos\PARCIAL II\";
            ofd.Filter = "Archivo plano (*.csv)|*.csv";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var archivo = ofd.FileName;

                //lbl muestra archivo actual
                lblMostrarArchivoActual.Text = archivo;

                string resultado = ar.leerTodoArchivo(archivo);
                ArregloNotas = ar.LeerArchivo(archivo);

                textBoxResultado.Text = resultado;
            }

        }//End Carga .CSV


        private void buttonNombres_Click(object sender, EventArgs e)
        {
            string[,] ArregloDosDimensiones = new string[ArregloNotas.Length, 6];
            int NumeroLinea = 0;


            foreach (string linea in ArregloNotas)
            {
                string[] datosUnitarios = linea.Split(';');
                ArregloDosDimensiones[NumeroLinea, EnumColumnas.correlativo] = datosUnitarios[0]; //Se agrega el correlativo, numeroLinea = 0
                ArregloDosDimensiones[NumeroLinea, EnumColumnas.Nombre] = datosUnitarios[1]; //Se agrega el nombre
                ArregloDosDimensiones[NumeroLinea, EnumColumnas.ParcialUno] = datosUnitarios[2]; // Agrega nota parcial uno a la matriz
                ArregloDosDimensiones[NumeroLinea, EnumColumnas.ParcialDos] = datosUnitarios[3]; // ....
                ArregloDosDimensiones[NumeroLinea, EnumColumnas.ParcialTres] = datosUnitarios[4]; // ....
                ArregloDosDimensiones[NumeroLinea, EnumColumnas.Seccion] = datosUnitarios[5]; // ....

                NumeroLinea++; //para ir iterando las filas. 
            }
            //int promedio;
            //promedio = 0;

            MessageBox.Show($"Promedio General (A,B,C,D): \n" +
                $"Parcial I:\t{promedios(ArregloDosDimensiones, EnumColumnas.ParcialUno).ToString()} pts.\n" +
                $"Parcial II:\t{promedios(ArregloDosDimensiones, EnumColumnas.ParcialDos).ToString()} pts.\n" +
                $"Parcil III:\t{promedios(ArregloDosDimensiones, EnumColumnas.ParcialTres).ToString()} pts.", "Promedios");


            //Muestra promedios para la seccion A,B,C.
            var PromA = MostrarPromedios(ArregloDosDimensiones, "A");
            var PromB = MostrarPromedios(ArregloDosDimensiones, "B");
            var PromC = MostrarPromedios(ArregloDosDimensiones, "C");
            var PromD = MostrarPromedios(ArregloDosDimensiones, "D");





        }//End ButtonNombresClick


        //Funcion para promedios
        private int promedios(string[,] matriz, int col)
            {
                int acum = 0;
                int prom = 0;
                int cantFilas = matriz.GetLength(0); //Asigna dimensiones de fila


                for (int i = 1; i < cantFilas; i++) //Comienza en 1, para evitar el encabezado.
                {
                    acum += Convert.ToInt32(matriz[i,col]);
                }

                prom = acum / (cantFilas - 1);

                return prom;
            }//End promedios()


            private int promedioSeccion(string[,] matriz,int col,string seccion)
        {
            int acum = 0; // Acumula la suma de los 3 parciales
            int acumEstudiantes = 0; //Acumula la cantidad de estudiantes de la seccion x
            int promedio = 0;
            int cantFilas = matriz.GetLength(0); 


            for (int i = 1; i < cantFilas; i++) //Comienza en 1, para evitar el encabezado.
            {
                if (matriz[i, 5] == seccion) //Busca fila x fila, en la columna 5 por incidencias con la seccion x.
                {
                    acum += Convert.ToInt32(matriz[i, col]); 

                    acumEstudiantes++;
                }
            }

            promedio = acum / acumEstudiantes;

            return promedio;
        }

        private int sumaPromedios(int prom1, int prom2, int prom3)
        {
            return ((prom1 + prom2 + prom3)/(3));
        }


        private int MostrarPromedios(string[,] matriz, string seccion)
        {
            //Muestra promedios para la seccion A.
            var promP1 = promedioSeccion(matriz, EnumColumnas.ParcialUno, seccion);
            var promP2 = promedioSeccion(matriz, EnumColumnas.ParcialDos, seccion);
            var promP3 = promedioSeccion(matriz, EnumColumnas.ParcialTres, seccion);

            var promedios = sumaPromedios(promP1, promP2, promP3);


            MessageBox.Show($"PARCIAL I - PROMEDIO: {promP1} PTS.\n" +
                            $"PARCIAL II - PROMEDIO: {promP2} PTS.\n" +
                            $"PARCIAL III - PROMEDIO: {promP3} PTS.\n\n" +
                            $"PROM. GENERAL = {promedios} PTS EN TOTAL.", $"SECCION {seccion}");

            return promedios;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            ClsChuno promedio = new ClsChuno();
            string[,] ArregloDosDimensiones = new string[ArregloNotas.Length, 6];
            int NumerLin = 0;

            foreach (string linea in ArregloNotas)
            {

                string[] DatosUnitarios = linea.Split(';');
                ArregloDosDimensiones[NumerLin, EnumColumnas.correlativo] = DatosUnitarios[0];
                ArregloDosDimensiones[NumerLin, EnumColumnas.Nombre] = DatosUnitarios[1];
                ArregloDosDimensiones[NumerLin, EnumColumnas.ParcialUno] = DatosUnitarios[2];
                ArregloDosDimensiones[NumerLin, EnumColumnas.ParcialDos] = DatosUnitarios[3];
                ArregloDosDimensiones[NumerLin, EnumColumnas.ParcialTres] = DatosUnitarios[4];
                ArregloDosDimensiones[NumerLin, EnumColumnas.Seccion] = DatosUnitarios[5];
                NumerLin++;
            }

            string[,] alumnoClasificado = promedio.Clasificar_Alumnos(ArregloDosDimensiones, "B");
            string nomb = alumnoClasificado[0, 0];
            string not = alumnoClasificado[0, 1];

            listBox1.Items.Add($" --- ALUMNOS CON MEJORES NOTAS ---");
            listBox1.Items.Add($"SECCIÓN B:");
            listBox1.Items.Add($"Nombre: {nomb}");
            listBox1.Items.Add($"Sumatoria de los parciales: {not}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            ClsChuno promedio = new ClsChuno();
            string[,] ArregloDosDimensiones = new string[ArregloNotas.Length, 6];
            int NumerLin = 0;

            foreach (string linea in ArregloNotas)
            {

                string[] DatosUnitarios = linea.Split(';');
                ArregloDosDimensiones[NumerLin, EnumColumnas.correlativo] = DatosUnitarios[0];
                ArregloDosDimensiones[NumerLin, EnumColumnas.Nombre] = DatosUnitarios[1];
                ArregloDosDimensiones[NumerLin, EnumColumnas.ParcialUno] = DatosUnitarios[2];
                ArregloDosDimensiones[NumerLin, EnumColumnas.ParcialDos] = DatosUnitarios[3];
                ArregloDosDimensiones[NumerLin, EnumColumnas.ParcialTres] = DatosUnitarios[4];
                ArregloDosDimensiones[NumerLin, EnumColumnas.Seccion] = DatosUnitarios[5];
                NumerLin++;
            }

            string mayr = promedio.nombre_nota_mayor(ArregloDosDimensiones);


            listBox1.Items.Add($" --- ALUMNO CON PROMEDIO MAYOR ---");
            listBox1.Items.Add($"Nombre: {mayr}");
            var prom_mayor = new ClsChuno();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClsChuno promedio = new ClsChuno();
            string[,] ArregloDosDimensiones = new string[ArregloNotas.Length, 6];
            int NumerLin = 0;

            foreach (string linea in ArregloNotas)
            {

                string[] DatosUnitarios = linea.Split(',');
                ArregloDosDimensiones[NumerLin, EnumColumnas.correlativo] = DatosUnitarios[0];
                ArregloDosDimensiones[NumerLin, EnumColumnas.Nombre] = DatosUnitarios[1];
                ArregloDosDimensiones[NumerLin, EnumColumnas.ParcialUno] = DatosUnitarios[2];
                ArregloDosDimensiones[NumerLin, EnumColumnas.ParcialDos] = DatosUnitarios[3];
                ArregloDosDimensiones[NumerLin, EnumColumnas.ParcialTres] = DatosUnitarios[4];
                ArregloDosDimensiones[NumerLin, EnumColumnas.Seccion] = DatosUnitarios[5];
                NumerLin++;
            }

            string mayr = promedio.nombre_nota_mayor(ArregloDosDimensiones, "C");

            listBox1.Items.Add($" --- ALUMNO CON PROMEDIO MAYOR SECCIÓN C ---");
            listBox1.Items.Add($"Nombre: {mayr}");
        }
    }


}
