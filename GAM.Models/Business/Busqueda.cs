﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = GAM.Models.Models;

namespace GAM.Models.Business
{
    public class Busqueda : Repository.Busqueda
    {
        public List<m.Modelos> Seleccionar_Busqueda(string nombre)
        {
            string s = nombre;

            string[] subs = s.Split(' ');

            string empresa = "";
            //Una sola palabra (puede ser una palabra o una empresa)
            if (subs.Length == 1)
            {
                if (Catalogos.SeleccionarConfirmarNombreExiste(subs[0]))
                {
                    empresa = nombre;
                    nombre = "";
                }
                else
                {
                    empresa = "";
                    nombre = subs[0];
                }                
            }
            else
            {
                //dos palabras (una debe ser una empresa)
                foreach (var sub in subs)
                {
                    //Buscar si una palabra que viene es una empresa existente
                    if (Catalogos.SeleccionarConfirmarNombreExiste(sub))
                    {
                        empresa = sub;
                    }
                    else
                    {
                        nombre = sub;
                    }
                }
            }

            return SeleccionarBusqueda(nombre, empresa);

        }

        public List<m.Modelos> Seleccionar_Busqueda2(string nombre)
        {
            string s = nombre;

            string[] subs = s.Split(' ');

            string empresa = "";
            //Una sola palabra (puede ser una palabra o una empresa)
            if (subs.Length == 1)
            {
                if (Catalogos.SeleccionarConfirmarNombreExiste(subs[0]))
                {
                    empresa = subs[0];
                    nombre = "";
                }
                else
                {
                    empresa = "";
                    nombre = subs[0];
                }
            }
            else
            {
                //dos palabras (una debe ser una empresa)
                foreach (var sub in subs)
                {
                    //Buscar si una palabra que viene es una empresa existente
                    if (Catalogos.SeleccionarConfirmarNombreExiste(sub))
                    {
                        empresa = sub;
                    }
                    else
                    {
                        nombre = sub;
                    }
                }
            }

            return SeleccionarBusqueda2(nombre, empresa);
        }

        public List<m.Modelos> Seleccionar_Busqueda3(string nombre)
        {
            return SeleccionarBusqueda3(nombre);
        }
    }
}
