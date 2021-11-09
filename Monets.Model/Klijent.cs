﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Monets.Model
{
    public class Klijent
    {
        public int KlijentId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public DateTime DatumUclanjenja { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string SlikaPutanja { get; set; }
        public byte[] Slika { get; set; }
        public bool? Status { get; set; }
        public virtual Model.Grad Grad { get; set; }
    }
}