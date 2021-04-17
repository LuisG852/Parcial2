using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialDos
{
      interface Interface
    {
        /// <summary>
        /// retorna el promedio en base a una columna especifica
        /// </summary>
        /// <param name="matriz"></param>
        /// <param name="columanparcial"></param>
        /// <returns></returns>
        int promedios_por_parcial(string[,] matriz, int columan_parcial);


        /// <summary>
        /// retorna el promedio de un parcial y una seccion en especial
        /// </summary>
        /// <param name="matriz"></param>
        /// <param name="columnaparcial"></param>
        /// <param name="seccion"></param>
        /// <returns></returns>
        int promedio_por_seccion(string[,] matriz, int columna_parcial, string seccion);

        /// <summary>
        /// saca el proimedio general de todos los alumnos por seccion.
        /// </summary>
        /// <param name="matriz"></param>
        /// <param name="columnaparcial"></param>
        /// <param name=""></param>
        /// <returns></returns>
        int promedio_general_seccion(string[,] matriz, int columna_parcial, string seccion);

        /// <summary>
        /// retorna una matriz de 2 columnas con el nombre y la otra columna ses la sumatoria del 1 al 3.
        /// </summary>
        /// <param name="matriz"></param>
        /// <param name="seccion"></param>
        /// <returns></returns>
        string[,] Clasificar_Alumnos(string[,] matriz, string seccion);


        /// <summary>
        /// busca el mejor promedio genera o por seccion.
        /// </summary>
        /// <param name="matriz"></param>
        /// <param name="seccion"></param>
        /// <returns></returns>
        string nombre_nota_mayor(string[,] matriz);
        string nombre_nota_mayor(string[,] matriz, string seccion);
    }
}
