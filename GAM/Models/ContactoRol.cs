﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAM.Models
{
    public class ContactoRol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdClasificacionRolesContactos { get; set; }
        public string ClasificacionRolesContactosNombre { get; set; }
    }
}