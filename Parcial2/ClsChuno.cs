using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialDos
{
    class ClsChuno : Interface
    {
        public string[,] Clasificar_Alumnos(string[,] matriz, string seccion)
        {
            string[,] alumnos = new string[1, 2];

            int actual;
            int mayor = 0;
            int TotalFilas = matriz.GetLength(0);
            int filasSecc = TotalFilas;
            int TotalColumnas = matriz.GetLength(1);
            for (int fila = 1; fila < TotalFilas; fila++)
            {

                if (matriz[fila, EnumColumnas.Seccion] == seccion)
                {

                    actual = Convert.ToInt32(matriz[fila, EnumColumnas.ParcialUno])
                            + Convert.ToInt32(matriz[fila, EnumColumnas.ParcialDos])
                            + Convert.ToInt32(matriz[fila, EnumColumnas.ParcialTres]);



                    if (mayor > actual)
                    {
                        alumnos[0, 1] = mayor.ToString();

                    }
                    else
                    {
                        alumnos[0, 0] = matriz[fila, EnumColumnas.Nombre];
                        alumnos[0, 1] = actual.ToString();
                        mayor = actual;
                    }



                }


            }

            return alumnos;
        }

        public string nombre_nota_mayor(string[,] matriz)
        {
            string nombre = "";

            int actual;
            int mayor = 0;
            int TotalFilas = matriz.GetLength(0);
            int filasSecc = TotalFilas;
            int TotalColumnas = matriz.GetLength(1);
            for (int fila = 1; fila < TotalFilas; fila++)
            {

                int p1 = Convert.ToInt32(matriz[fila, EnumColumnas.ParcialUno]);
                int p2 = Convert.ToInt32(matriz[fila, EnumColumnas.ParcialDos]);
                int p3 = Convert.ToInt32(matriz[fila, EnumColumnas.ParcialTres]);

                actual = (p1 + p2 + p3) / 3;

                if (actual > mayor)
                {
                    nombre = matriz[fila, EnumColumnas.Nombre];
                    mayor = actual;
                }
            }

            return nombre;
        }

        public string nombre_nota_mayor(string[,] matriz, string seccion)
        {
            string nombre = "";

            int actual;
            int mayor = 0;
            int TotalFilas = matriz.GetLength(0);
            int filasSecc = TotalFilas;
            int TotalColumnas = matriz.GetLength(1);


            for (int fila = 1; fila < TotalFilas; fila++)
            {
                if (matriz[fila, EnumColumnas.Seccion] == seccion)
                {
                    int p1 = Convert.ToInt32(matriz[fila, EnumColumnas.ParcialUno]);
                    int p2 = Convert.ToInt32(matriz[fila, EnumColumnas.ParcialDos]);
                    int p3 = Convert.ToInt32(matriz[fila, EnumColumnas.ParcialTres]);

                    actual = (p1 + p2 + p3) / 3;

                    if (actual > mayor)
                    {
                        nombre = matriz[fila, EnumColumnas.Nombre];
                        mayor = actual;
                    }
                }

            }

            return nombre;
        }

        public int promedios_por_parcial(string[,] matriz, int columan_parcial)
        {
            throw new NotImplementedException();
        }

        public int promedio_general_seccion(string[,] matriz, string seccion)
        {
            int Acum = 0;
            int Prom;
            int TotalFilas = matriz.GetLength(0);
            int filasSecc = TotalFilas;
            int TotalColumnas = matriz.GetLength(1);
            for (int fila = 1; fila < TotalFilas; fila++)
            {
                if (matriz[fila, EnumColumnas.Seccion] == seccion)
                {
                    Acum = Acum
                        + Convert.ToInt32(matriz[fila, EnumColumnas.ParcialUno])
                        + Convert.ToInt32(matriz[fila, EnumColumnas.ParcialDos])
                        + Convert.ToInt32(matriz[fila, EnumColumnas.ParcialTres]);
                }
                else
                {
                    filasSecc--;
                }

            }

            Prom = (Acum / (filasSecc - 1)) / 3;
            return Prom;
        }

        public int promedio_general_seccion(string[,] matriz, int columna_parcial, string seccion)
        {
            throw new NotImplementedException();
        }

        public int promedio_por_parcial(string[,] matriz, int columna_parcial)
        {
            int Acum = 0;
            int Prom;
            int TotalFilas = matriz.GetLength(0);
            int TotalColumnas = matriz.GetLength(1);
            for (int fila = 1; fila < TotalFilas; fila++)
            {
                Acum = Acum + Convert.ToInt32(matriz[fila, columna_parcial]);
            }
            Prom = Acum / (TotalFilas - 1);
            return Prom;
        }

        public int promedio_por_seccion(string[,] matriz, int columna_parcial, string seccion)
        {
            int Acum = 0;
            int Prom;
            int TotalFilas = matriz.GetLength(0);
            int filasSecc = TotalFilas;
            int TotalColumnas = matriz.GetLength(1);
            for (int fila = 1; fila < TotalFilas; fila++)
            {
                if (matriz[fila, EnumColumnas.Seccion] == seccion)
                {
                    Acum = Acum + Convert.ToInt32(matriz[fila, columna_parcial]);


                }
                else
                {
                    filasSecc--;
                }

            }
            Prom = Acum / (filasSecc - 1);
            return Prom;
        }
    }
}
